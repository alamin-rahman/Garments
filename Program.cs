using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.DashboardWin.Native;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Customization;
using Purchesed.DevForm;
using Purchesed.DevForm.Common;
using Purchesed.Report;

namespace Purchesed{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
           Application.SetCompatibleTextRenderingDefault(false);
             // Application.Run(new Form1());
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetDefaultStyle();
          //  Application.Run( new DashBoard());
          //  Application.Run(new CompanyInformation());
           // Application.Run(new AddItem());
          //  Application.Run(new Product_Add_Company());
           // Application.Run(new TrimeOrderRequest());
          //  Application.Run(new Trime());
           // Application.Run(new MeterialOrderRequest());
          //Application.Run(new TrimeSuplier());
         //   Application.Run(new AddressReport());// Application.Run(new MetarialSuplierInformation());
          // Application.Run(new Trimes());
           // Application.Run(new Metarials());
         //  Application.Run(new TrimeSampleRequest());Application.Run(new TrimeLab());//   Application.Run(new Deshboard());
        //  Application.Run(new MetarialQuotationList());//   
           // Application.Run(new Origien());
           // Application.Run(new Unite());
           // Application.Run(new FactoryInformation());

           // Application.Run(new FactoryList());
           // Application.Run(new TrimeOrderRequest());
           // Application.Run(new Color());

           // Application.Run(new Color());
        //   Application.Run(new TrimeQuotationList());
        //   Application.Run(new FactoryTrimeOrderRequest());
           // Application.Run(new FactoryMaterialOrderRequestcs());



         //  Application.Run(new FactoryList());
         //   Application.Run(new TrimeSampleRequest());
          //Application.Run(new TrimeSampleRecive());
        //   Application.Run(new TrimeLab());
       //  Application.Run(new TrimeSuplierInformation());
      //  Application.Run(new TrimeSampleRequest());
       // Application.Run(new TrimeSuplierList());
        //    Application.Run(new TrimeSuplierList());
         //  Application.Run(new CurrencyExchange());
          // Application.Run(new SuplierDelete());
         Application.Run(new LOG_IN());
          // Application.Run(new BtnAdd1()); 

          //  Application.Run(new TrimeQuotation());
           //Application.Run(new Trimes());
        }
    }
}
