using System.Collections.Generic;
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
			{  "Dallimore", "https://napier.govt.nz/assets/Contacts/Councillor-Larry-Dallimore-Oct-2016-8.jpg" },
			{ "Dalton", "https://napier.govt.nz/assets/Contacts/Mayor-Bill-Dalton-Oct-2016-3.jpg" },
			{ "Hague", "https://napier.govt.nz/assets/Contacts/Councillor-Claire-Hague-Oct-2016-6.jpg" },
			{ "Jeffery", "https://napier.govt.nz/assets/Contacts/Councillor-Tony-Jefferies-Mar-2017-2.jpg" },
			{ "McGrath", "https://napier.govt.nz/assets/Contacts/Councillor-Richard-McGrath-Oct-2016-2.jpg" },
			{ "Price", "https://napier.govt.nz/assets/Contacts/Councillor-Keith-Price-Oct-2016-2.jpg" },
			{ "Tapine", "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Apiata-Tapine-Oct-2016.jpg" },
			{ "Taylor", "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Graeme-Taylor-Oct-2016-7.jpg" },
			{ "White", "https://napier.govt.nz/assets/Contacts/Councillor-Faye-White-Oct-2016.jpg" },
			{ "Wise", "https://napier.govt.nz/assets/Contacts/Councillor-Kirsten-Wise-Mar-2017.jpg" },
			{ "Wright", "https://napier.govt.nz/assets/Contacts/Councillor-Tania-Wright-Oct-2016-12.jpg" }

		};
		public ActionResult Index( )
		{
			MeetingAttendanceList vm = new MeetingAttendanceList( );
			vm.Attendees = new List<OfficialListItem>( );

			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Boag", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Maxine-Boag-Oct-2016-5.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 2, Name = "Brosnan", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Annette-Brosnan-Oct-2016-7.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 2, Name = "Dallimore", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Larry-Dallimore-Oct-2016-8.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 2, Name = "Dalton", Attendances = 1, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Mayor-Bill-Dalton-Oct-2016-3.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Hague", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Claire-Hague-Oct-2016-6.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Jeffrey", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Tony-Jefferies-Mar-2017-2.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "McGrath", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Richard-McGrath-Oct-2016-2.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Price", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Keith-Price-Oct-2016-2.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Tapine", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Apiata-Tapine-Oct-2016.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Taylor", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/_resampled/FillWyI4MDAiLCI4MDAiXQ-Councillor-Graeme-Taylor-Oct-2016-7.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "White", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Faye-White-Oct-2016.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Wise", Attendances = 4, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Kirsten-Wise-Mar-2017.jpg" } );
			//vm.Attendees.Add( new OfficialListItem { Id = 1, Name = "Wright", Attendances = 1, ProfileImageUrl = "https://napier.govt.nz/assets/Contacts/Councillor-Tania-Wright-Oct-2016-12.jpg" } );

			using ( creo_dbEntities dbContext = new creo_dbEntities( ) )
			{
				foreach ( Official official in dbContext.Officials )
				{
					string url = null;
					urlDict.TryGetValue( official.Name, out url );
					vm.Attendees.Add( new OfficialListItem { Id = official.Id, Attendances = official.Attendances.Count, Name = official.Name, ProfileImageUrl = url} );
				}
			}

			vm.Attendees = vm.Attendees.OrderByDescending( a => a.Attendances ).ToList(  );

			vm.MaxAttending = vm.Attendees.Select( a => a.Attendances ).Max();

			return View( vm );
		}

		public ActionResult OverView( )
		{
			ViewBag.Message = "foobar.";

			return View( );
		}

		public ActionResult Contact( )
		{
			ViewBag.Message = "Your contact page.";

			return View( );
		}

		public ActionResult CouncillorsAttendance( )
		{
			return View( );
		}
	}
}