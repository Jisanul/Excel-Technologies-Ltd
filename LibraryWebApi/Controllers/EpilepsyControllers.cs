//using Microsoft.AspNetCore.Mvc;
//using PatientWebApi.Models;

//namespace PatientWebApi.Controllers
//{
//    public class EpilepsyControllers : Controller
//    {
//        // GET: api/epilepsy
//        [HttpGet]
//        public ActionResult<IEnumerable<string>> GetEpilepsyStatuses()
//        {
//            var epilepsyStatuses = Enum.GetNames(typeof(Epilepsy));
//            return Ok(epilepsyStatuses);
//        }

//        // GET: api/epilepsy/values
//        [HttpGet("values")]
//        public ActionResult<IEnumerable<int>> GetEpilepsyValues()
//        {
//            var epilepsyValues = Enum.GetValues(typeof(Epilepsy)).Cast<int>();
//            return Ok(epilepsyValues);
//        }

//        // GET: api/epilepsy/No
//        [HttpGet("{status}")]
//        public ActionResult<int> GetEpilepsyValue(string status)
//        {
//            if (Enum.TryParse(status, out Epilepsy epilepsyStatus))
//            {
//                return Ok((int)epilepsyStatus);
//            }
//            return BadRequest("Invalid epilepsy status");
//        }
//    }
//}
