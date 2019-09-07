using CoreEtl.Models.FromScraper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEtl.Transform.FromScraper
{
	class LoadMeetingFile
	{
		public List<MeetingMetaData> LoadFile( string url )
		{
			using ( var reader = new StreamReader( @"..\..\..\DataSources\ncc2019.csv" ) )
			{
				List<MeetingMetaData> Meetings = new List<MeetingMetaData>( );

				while ( !reader.EndOfStream )
				{
					MeetingMetaData Meeting = new MeetingMetaData( );
					var line = reader.ReadLine( );
					var values = line.Split( ',' );

					if ( values[ 0 ] == "Organisation" )
					{
						continue;
					}

					Meeting.Organisation = values[ 0 ];
					if ( !string.IsNullOrEmpty( values[ 1 ] ) )
					{
						if ( values[ 1 ][ 1 ] == '/' )
						{
							values[ 1 ] = '0' + values[ 1 ];
						}
						Meeting.Date = DateTime.ParseExact( values[ 1 ], "dd/MM/yyyy",
											   CultureInfo.InvariantCulture );
					}
					Meeting.Meeting = values[ 2 ];
					Meeting.Official = values[ 3 ];
					Meeting.FirstName = values[ 4 ];
					Meeting.Notes = values[ 5 ];

					Meetings.Add( Meeting );

				}

				Console.WriteLine( $"Loaded in {Meetings.Count} lines in file." );
				return Meetings;
			}

		}
	}
}
