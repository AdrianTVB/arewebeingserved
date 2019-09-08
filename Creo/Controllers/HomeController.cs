﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Creo.ViewModels.MeetingAttendance;
using Creo.ViewModels.Official;
using Domain.EntityFramework;

namespace Creo.Controllers
{
	public class HomeController : Controller
	{

		private static Dictionary<string, string> urlDict = new Dictionary<string, string>
		{
			{ "Boag", "https://napier.govt.nz/assets/Contacts/Councillor-Maxine-Boag-Oct-2016-5.jpg" },
			{ "Brosnan", "https://napier.govt.nz/assets/Contacts/Councillor-Annette-Brosnan-Oct-2016-7.jpg" },
			{ "Dallimore", "https://napier.govt.nz/assets/Contacts/Councillor-Larry-Dallimore-Oct-2016-8.jpg" },
			{ "Dalton", "https://napier.govt.nz/assets/Contacts/Mayor-Bill-Dalton-Oct-2016-3.jpg" },
			{ "Hague", "https://napier.govt.nz/assets/Contacts/Councillor-Claire-Hague-Oct-2016-6.jpg" },
			{ "Jeffery", "https://napier.govt.nz/assets/Contacts/Councillor-Tony-Jefferies-Mar-2017-2.jpg" },
			{ "McGrath", "https://napier.govt.nz/assets/Contacts/Councillor-Richard-McGrath-Oct-2016-2.jpg" },
			{ "Price", "https://napier.govt.nz/assets/Contacts/Councillor-Keith-Price-Oct-2016-2.jpg" },
			{ "Tapine", "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Apiata-Tapine-Oct-2016.jpg" },
			{ "Taylor", "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Graeme-Taylor-Oct-2016-7.jpg" },
			{ "White", "https://napier.govt.nz/assets/Contacts/Councillor-Faye-White-Oct-2016.jpg" },
			{ "Wise", "https://napier.govt.nz/assets/Contacts/Councillor-Kirsten-Wise-Mar-2017.jpg" },
			{ "Wright", "https://napier.govt.nz/assets/Contacts/Councillor-Tania-Wright-Oct-2016-12.jpg" },

			//Hastings
			{ "Hazlehurst", "https://www.hastingsdc.govt.nz/assets/Contacts/SandraHazlehurst-HDCweb.jpg" },
			{ "Kerr", "https://www.hastingsdc.govt.nz/assets/Contacts/TaniaKerr-HDCweb.jpg" },
			{ "Barber", "https://www.hastingsdc.govt.nz/assets/Contacts/BaydenBarber-HDCweb.jpg" },
			{ "Dixon", "https://www.hastingsdc.govt.nz/assets/Contacts/MalcolmDixon-HDCweb.jpg" },
			{ "Harvey", "https://www.hastingsdc.govt.nz/assets/Contacts/DamonHarvey-HDCweb.jpg" },
			{ "Heaps", "https://www.hastingsdc.govt.nz/assets/Contacts/RodHeaps-HDCweb.jpg" },
			{ "Lawson", "https://www.hastingsdc.govt.nz/assets/Contacts/EileenLawson-HDCweb.jpg" },
			{ "Lyons", "https://www.hastingsdc.govt.nz/assets/Contacts/GeorgeLyons-HDCweb.jpg" },
			{ "Nixon", "https://www.hastingsdc.govt.nz/assets/Contacts/SimonNixon-HDCweb.jpg" },
			{ "O’Keefe", "https://www.hastingsdc.govt.nz/assets/Contacts/HenareOkeefe-HDCweb.jpg" },
			{ "Poulain", "https://www.hastingsdc.govt.nz/assets/Contacts/JacobyPoulain-HDCweb.jpg" },
			{ "Redstone", "https://www.hastingsdc.govt.nz/assets/Contacts/AnnRedstone-HDCweb.jpg" },
			{ "Travers", "https://www.hastingsdc.govt.nz/assets/Contacts/GeraldineTravers-HDCweb.jpg" },
			{ "Watkins", "https://www.hastingsdc.govt.nz/assets/Contacts/KevinWatkins-HDCweb.jpg" },
		};

		public ActionResult Index( )
		{
			return View( );
		}


		[OutputCache( Duration = 86400, VaryByParam = "organisationid" )]
		public ActionResult ListOfCouncillors( int organisationid )
		{
			MeetingAttendanceList vm = new MeetingAttendanceList( );
			vm.Attendees = new List<OfficialListItem>( );

			using ( creo_dbEntities dbContext = new creo_dbEntities( ) )
			{
				foreach ( Official official in dbContext.Officials.Where( w => w.OrganisationId == organisationid ) )
				{
					string url = null;
					urlDict.TryGetValue( official.Name, out url );
					if ( official.Attendances.Count > 2 )
					{
						vm.Attendees.Add( new OfficialListItem { Id = official.Id, Attendances = official.Attendances.Count, Name = official.Name, ProfileImageUrl = url } );

					}
				}
			}

			vm.Attendees = vm.Attendees.OrderByDescending( a => a.Attendances ).ToList( );

			vm.MaxAttending = vm.Attendees.Select( a => a.Attendances ).Max( );
			vm.Title = organisationid == 13 ? "Napier City Councillors" : "Hastings District Councillors";

			return View( vm );
		}

		public ActionResult Report( )
		{
			ViewBag.Message = "foobar.";

			return View( );
		}

		public ActionResult About( )
		{
			ViewBag.Message = "About this project";

			return View( );
		}

		public ActionResult Contact( )
		{
			ViewBag.Message = "Your About page.";

			return View( );
		}

		public ActionResult CouncillorsAttendance( )
		{
			return View( );
		}
	}
}