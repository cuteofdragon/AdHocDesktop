using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;

using Microsoft.Win32;

namespace AdHocDesktop.Core
{
    public class FirewallUtil
    {
        public static void AuthroizeEntryAssembly()
        {
            // How to control a base firewall included in Windows XP SP2 using COM.  
			try
			{
				Assembly asm = Assembly.GetEntryAssembly();
                string asmPath = Path.GetFullPath(asm.CodeBase.Replace("file:///", ""));                
				Type titleType = typeof(AssemblyProductAttribute);
				object[] attrs = asm.GetCustomAttributes(titleType, false);
				AssemblyProductAttribute asmProductAttr  = (AssemblyProductAttribute)attrs[0];			

				INetFwMgr mgr = (INetFwMgr)new NetFwMgr();
				INetFwProfile profile = mgr.LocalPolicy.CurrentProfile;

				bool isAuthroized = false;
				IEnumerator e = profile.AuthorizedApplications._NewEnum;
				while(e.MoveNext())
				{
					INetFwAuthorizedApplication app = e.Current as INetFwAuthorizedApplication;
                    if (asmPath.ToLower() == app.ProcessImageFileName.ToLower())
					{
						isAuthroized = true;
						break;
					}
				}				

				if(!isAuthroized)
				{
					INetFwAuthorizedApplication app = (INetFwAuthorizedApplication)new NetFwAuthorizedApplication();
					app.Enabled = true;
					app.Name = asmProductAttr.Product;
					app.Scope = Scope.All;
                    app.ProcessImageFileName = asmPath;
					profile.AuthorizedApplications.Add(app); 
					Marshal.ReleaseComObject(app);
				}
				Marshal.ReleaseComObject(mgr);
			}
			catch (Exception e)
			{
                System.Windows.Forms.MessageBox.Show(e.ToString());
			}
        }
    }
}
