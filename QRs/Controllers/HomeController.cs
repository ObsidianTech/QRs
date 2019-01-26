using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using QRs.Models;

namespace QRs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCode(string input)
        {
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
            SvgQRCode qrCode = new SvgQRCode(data);
            string qrCodeSVG = qrCode.GetGraphic(20);
            QRString qrs = new QRString(qrCodeSVG);

            return View(qrs);
        }

        public class QRString
        {
            public string QRSVG { get; set; }
            public QRString(string qrstring)
            {
                QRSVG = qrstring;
            }
        }
    }
}
