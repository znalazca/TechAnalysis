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

/*
 * Created by SharpDevelop.
 * User: chm
 * Date: 24.04.2010
 * Time: 17:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ParseProject
{
	class Program
	{
		public static void Main(string[] args)
		{
			Func func = new Func();
			
			foreach(string directory in Directory.GetDirectories("."))
			{
				func.ProcessDirectory(directory);
			}
			
			func.WriteLog();
		}
	}
		
	public class Func
	{
		StringBuilder sb;
		
		bool isMethod;
		bool isBeginMethod;
		
		public Func()
		{
			sb = new StringBuilder();
			
			isMethod = false;
			isBeginMethod = false;
		}
		
		public void WriteLog()
		{
			StreamWriter sw = new StreamWriter("log.txt");
			sw.Write(sb.ToString());
			sw.Close();
		}
		
		public void ProcessFile(string file)
		{
			if(Path.GetExtension(file) == ".cs")
			{
				StringBuilder filebuilder = new StringBuilder();
				
				StreamReader sr = new StreamReader(file);
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					
					if((Regex.IsMatch(line, @"[a-zA-z_]+ *(\(.+\)|\(\))")) &&
					   (!line.Contains(";")) &&
					   (!line.Contains("if")) &&
					   (!line.Contains("[")) &&
					   (!line.Contains("]")) &&
					   (!Regex.IsMatch(line, @"^//")) &&
					   (!Regex.IsMatch(line, @"^\(")) &&
					   (!line.Contains("||")) &&
					   (!line.Contains("&&")) &&
					   (!line.Contains("while")) &&
					   (!line.Contains("foreach")) &&
					   (!line.Contains("InitializeComponent()")) &&
					   (!line.Contains("catch")))
					{
						isMethod = true;
					}
					
					if(isBeginMethod)
					{
						filebuilder.AppendLine("ExpressionTree.Trace.GetTrace();");
						filebuilder.AppendLine("");
						
						isBeginMethod = false;
					}
					
					if(line.Contains("{") && (isMethod))
					{
						isBeginMethod = true;
						isMethod = false;
					}
					
					filebuilder.AppendLine(line);
					
					if((line.Contains("{")) && (line.Contains("}")))
					{
						Console.WriteLine(line);
					}
				}
				
				sr.Close();
				
				StreamWriter processedwriter = new StreamWriter(file);
				processedwriter.Write(filebuilder.ToString());
				processedwriter.Close();
			}
		}
		
		public void ProcessDirectory(string directory)
		{
			foreach(string file in Directory.GetFiles(directory))
			{
				this.ProcessFile(file);
			}
			
			foreach(string subDirectory in Directory.GetDirectories(directory))
			{
				this.ProcessDirectory(subDirectory);
			}
		}
	}
}