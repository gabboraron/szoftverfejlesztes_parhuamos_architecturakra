using System.Threading;
using System;

namespace Locks
{
	class MyThread
	{
		static int a = 100000000;
		static string s_lock = "";


		public void Run()
		{
			Thread.Sleep( new Random().Next( 100 ) );

			Console.WriteLine( "Thread: {0} is running", Thread.CurrentThread.GetHashCode() );

			while( a > 0 )
			{
//				lock( s_lock )
				{
					int b = a;
					a--;
					if( b - 1 != a )
						Console.WriteLine( "hiba: {0}", Thread.CurrentThread.GetHashCode() );
				}
			}
		}
	}


	class Class1
	{
		static void Main(string[] args)
		{
			MyThread mt1 = new MyThread();
			MyThread mt2 = new MyThread();
			Thread t1 = new Thread( new ThreadStart( mt1.Run ) );
			Thread t2 = new Thread( new ThreadStart( mt2.Run ) );

			t1.Start();
			t2.Start();
		}
	}
}
