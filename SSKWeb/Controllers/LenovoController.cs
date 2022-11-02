using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SSKWeb.Helpers;
using SSKWeb.Models.ViewModels;
using SSKWeb.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

namespace SSKWeb.Controllers
{

    public class LenovoController : Controller
    {
        private ApiServices _service = new ApiServices();
        private CollectQueueListApiServices _collectQueueListApiService = new CollectQueueListApiServices();

        #region View and No Logic will specify
        //public async Task<IActionResult> SelectAction()
        //{
        //    await Task.CompletedTask;
        //    return View();
        //}
        public async Task<IActionResult> SelectSearchType()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> OutWarrantyConfirmRepair()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> ThankYouPage()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> ProblemDescription()
        {
            var data = await _service.GetProblemDescriptionAsync();
            data.RemoveAll(x=> x.productDesc == "Others");
            ProblemDescriptionViewModel problemDescriptionViewModel = new ProblemDescriptionViewModel();

            problemDescriptionViewModel.ProblemDescriptions = data;
            await Task.CompletedTask;
            return View(problemDescriptionViewModel);
        }

        public async Task<IActionResult> AgreeToReformatPage()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> ConfirmationPage()
        {
            var session = AppSession.GetInstance();
            var vm = new PostRegisterCustomerInfoModel()
            {
                Serial = session.Serial,
                InWarranty = session.InWarranty,
                customerName = session.customerName,
                customerEmail = session.customerEmail,
                customerPhoneNumber = session.customerPhoneNumber,
                jobDeviceSerial = session.jobDeviceSerial,
                jobProblemDescription = session.jobProblemDescription,
                isReturnDropOff = session.isReturnDropOff,
                problemDescriptions = session.problemDescriptions
            };
            await Task.CompletedTask;
            return View(vm);
        }

        public async Task<IActionResult> TermsAndConditionPage()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> VerifyBySerialNo()
        {
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> JobInfo()
        {
            var session = AppSession.GetInstance();
            var vm = new ResultJobViewModel()
            {
                jobTag = session.jobTag,
                statusId = session.statusId
            };
            if (session.statusId == 12) {
                var collectNoti = new PostCollectQueueListViewModel()
                {
                    caseNo = vm.jobTag
                };
                await _collectQueueListApiService.PostCollectQueueListJobAsync(collectNoti);
            }
            
            await Task.CompletedTask;
            return View(vm);
        }

        public async Task<IActionResult> ScanQRCode()
        {
            var session = AppSession.GetInstance();
            session.IsQRCodeScanned = true;
            await Task.CompletedTask;
            return View();
        }

        public async Task<IActionResult> VerifyByCaseNo()
        {
            var session = AppSession.GetInstance();
            session.IsQRCodeScanned = true;
            await Task.CompletedTask;
            return View();
        }



        public async Task<IActionResult> RegisterCustomer()
        {
            var session = AppSession.GetInstance();
            var vm = new PostRegisterCustomerInfoModel()
            {
                Serial = session.Serial,
                InWarranty = session.InWarranty
            };

            await Task.CompletedTask;
            return View(vm);
        }

        public async Task<IActionResult> PrintLabel()
        {
            var vm = new PrintLabelViewModel();
            var session = AppSession.GetInstance();
            vm.CustomerName = session.customerName;
            vm.CustomerContact = session.customerPhoneNumber;
            vm.SerialNumber = session.Serial;
            vm.CaseNumber = session.jobtag;
            vm.WarrantyType = session.warrantyType;


            await Task.CompletedTask;

            return View(vm);
        }
        #endregion

        #region Data Flow

        [HttpGet(nameof(GetRepairInfoBySerial))]
        public async Task<IActionResult> GetRepairInfoBySerial(string serialNo)
        {
            var data = await _service.GetRepairInfoBySerialNoAsync(serialNo);

            #region If Api Validation Failed
            if (data.InWarranty == null)
            {
                return BadRequest(data);
            }
            #endregion

            #region Initial Session
            var session = AppSession.GetInstance();
            session.Serial = data.Serial;
            session.InWarranty = data.InWarranty;
            if (session.InWarranty == true)
            {
                session.warrantyType = "IW";
            }
            else if (session.InWarranty == false)
            {
                session.warrantyType = "OW";
            }

            #endregion
            if (data.InWarranty == false)
            {
                return Ok(new { Url = "/Lenovo/OutWarrantyConfirmRepair", InWarranty = data.InWarranty });
            }


            return Ok(new { Url = "/Lenovo/RegisterCustomer", InWarranty = data.InWarranty });
        }

        [HttpGet(nameof(SaveCustomerInfo))]
        public async Task<IActionResult> SaveCustomerInfo(string customerName, string customerPhoneNumber, string customerEmail)
        {
            var vm = new CustomerInfoViewModel()
            {
                customerName = customerName,
                customerPhoneNumber = customerPhoneNumber,
                customerEmail = customerEmail
            };
            #endregion

            #region Validate Model
            var isValidate = AppValidator.ValidateObject(vm);
            if (isValidate.Any())
            {
                return BadRequest(isValidate);
            }
            #endregion
            #region If Api Validation Failed

            #endregion

            #region Initial Session
            var session = AppSession.GetInstance();
            session.customerName = customerName;
            session.customerPhoneNumber = customerPhoneNumber;
            session.customerEmail = customerEmail;
            #endregion



            return Ok(new { Url = "/Lenovo/ProblemDescription" });
        }

        [HttpGet(nameof(SaveProblemDescription))]
        public async Task<IActionResult> SaveProblemDescription(string problemDescriptions, string otherProblemDescription = null)
        {
            List<string> pds = new List<string>();
            if (problemDescriptions != null)
            {
                pds = problemDescriptions.Split(',').ToList();
            }
            if (otherProblemDescription != null)
            {
                pds.Add(otherProblemDescription);
            }
            #region If Api Validation Failed
            if (pds.Count() == 0)
            {
                return BadRequest(new { ProblemDescription = "At least one problem is required" });
            }
            #endregion

            #region Initial Session
            var session = AppSession.GetInstance();
            session.problemDescriptions = pds;
            #endregion

            return Ok(new { Url = "/Lenovo/AgreeToReformatPage" });
        }

        [HttpGet(nameof(CreateJog))]
        public async Task<IActionResult> CreateJog()
        {
            #region Initial Session
            var session = AppSession.GetInstance();
            var vm = new PostRegisterCustomerInfoModel()
            {
                Serial = session.Serial,
                InWarranty = session.InWarranty,
                customerName = session.customerName,
                customerEmail = session.customerEmail,
                customerPhoneNumber = session.customerPhoneNumber,
                jobDeviceSerial = session.Serial,
                jobProblemDescription = string.Join(",", session.problemDescriptions),
                isReturnDropOff = session.isReturnDropOff,
                problemDescriptions = session.problemDescriptions
            };
            #endregion

            var data = await _service.PostJobAsync(vm);

            #region If Api Validation Failed
            if (data.Errors != null)
            {
                return BadRequest(data.Errors);
            }

            #endregion
            session.jobtag = data.jobtag;

            return Ok(new { Url = "/Lenovo/PrintLabel" });
        }

        [HttpGet(nameof(GetJogInfo))]
        public async Task<IActionResult> GetJogInfo(string jobTag, string page)
        {
            var data = await _service.GetJobInfoAsync(jobTag);

            #region If Api Validation Failed

            #endregion

            //var sessionClear = AppSession.GetInstance();
            //sessionClear.jobTag = null;
            //sessionClear.status = null;
            //sessionClear.statusId = null;
            //sessionClear.isExists = false;
            //sessionClear.warrantyType = null;
            //sessionClear.Serial = null;

            if (data.isExists == false)
            {
                return Ok(new { IsExists = false });
            }
            else if (data.isExists == true)
            {
                #region Initial Session
                var session = AppSession.GetInstance();
                session.jobTag = data.jobTag;
                session.status = data.status;
                session.statusId = data.statusId;
                session.isExists = data.isExists;
                session.warrantyType = data.warrantyType;
                session.Serial = data.serial;
                #endregion
            }

            return Ok(new { Url = page });
        }


        #region If Api Validation Failed
        [HttpGet]
        public async Task<IActionResult> IsQRScanned()
        {
            var session = AppSession.GetInstance();
            await Task.CompletedTask;
            if (!session.IsQRCodeScanned)
            {
                return Ok(new { Url = "/Lenovo/RegisterCustomer" });
            }
            else
            {
                return Ok(new { Url = "/Lenovo/PrintLabel" });
            }
        }
        #endregion



    }
}
