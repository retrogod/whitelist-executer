﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhitelistExecuter.Lib;
using WhitelistExecuter.Web.Models;

namespace WhitelistExecuter.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Whitelist Executer.";

            return View(new HomeModel());
        }

        [HttpPost]
        public ActionResult ExecuteCommand(HomeModel model)
        {
            model.Error = null;

            using (var client = new WhitelistExecuterClient())
            {
                ExecutionResult result;
                try
                {
                    result = client.API.ExecuteCommand(model.Command, model.RelativePath);
                }
                catch (Exception e)
                {
                    model.Error = (e.InnerException ?? e).Message;
                    return View("Index", model);
                }
                //.....ViewBag.ViewBag.mo
                model.StandardOutput = result.StandardOutput;
                model.StandardError = result.StandardError;

            }
            return View("Index", model);
        }
    }
}