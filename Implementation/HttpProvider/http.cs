/* Copyright 2008-2012 Dzmitry Gotowka (Hatouka) htotatut@gmail.com

The MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
and associated documentation files (the "Software"), to deal in the Software without restriction, 
including without limitation the rights to use, copy, modify, merge, publish, distribute, 
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or 
substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE. */

using System;
using System.Text;
using System.IO;
using System.Net;

namespace HttpProvider
{
	public class HttpManager
	{
		private string szServer;
		private string szPort;
		private string szLogin;
		private string szPassword;

		public string Server
		{
			get {return szServer;}
			set
			{
				if(value == "")
				{
					szServer = null;
				}
				else
				{
					szServer = value;
				}
			}
		}

		public string Port
		{
			get {return szPort;}
			set
			{
				if(value == "")
				{
					szPort = null;
				}
				else
				{
					szPort = value;
				}
			}
		}

		public string Login
		{
			get {return szLogin;}
			set
			{
				if(value == "")
				{
					szLogin = null;
				}
				else
				{
					szLogin = value;
				}
			}
		}

		public string Password
		{
			get {return szPassword;}
			set
			{
				if(value == "")
				{
					szPassword = null;
				}
				else
				{
					szPassword = value;
				}
			}
		}

		public string GetData(string szUrl)
		{
			StringBuilder sb = new StringBuilder();

			byte[] buf = new byte[8192];

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(szUrl);

			if((szServer != null)&&(szPort != null))
			{
				WebProxy myProxy = new WebProxy();
				Uri newUri = new Uri("http://" + szServer + ":" + szPort);
				myProxy.Address=newUri;
				if((szLogin != null)&&(szPassword != null))
				{
					myProxy.Credentials=new NetworkCredential(szLogin,szPassword);
					request.Proxy = myProxy;
				}
			}

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			Stream resStream = response.GetResponseStream();

			string tempString = null;
            int iCount = 0;

			do
            {
				iCount = resStream.Read(buf, 0, buf.Length);

				if (iCount != 0)
				{
					tempString = Encoding.ASCII.GetString(buf, 0, iCount);
					sb.Append(tempString);
				}
            }
			while (iCount > 0);

            string szText = sb.ToString();

			return szText;
		}
	}
}
