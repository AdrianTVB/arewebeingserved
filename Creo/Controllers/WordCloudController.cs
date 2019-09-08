using Creo.ViewModels.Images;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Creo.Controllers
{
	public class WordCloudController : Controller
	{

		private const int NapierCityCouncilId = 4;


		// GET: WordCloud
		public ActionResult Index( int organisationId )
		{
			List<WordCloudImage> images = new List<WordCloudImage>( );
			string path = "~/Images";
			path += "/Napier";
			images.Add( new WordCloudImage( path + "/napier_" + 0 + ".png" ) );

			if ( organisationId == NapierCityCouncilId )
			{
				ViewBag.Title = "Napier City Council";
			}
			else
			{
				ViewBag.Title = "Hastings District Council";
			}

			return View( images );
		}
	}
}