using System;
using System.Threading;

namespace ThreadPoolDemo
{
	class Program
	{
		static ManualResetEvent stopEvent = new ManualResetEvent( false );
		static volatile int num = 0;

		static void DoIt( object state )
		{
			Console.WriteLine( "doit called, thread: {0}, num: {1} ", Thread.CurrentThread.GetHashCode(), num);
			Thread.Sleep( 1000 );
			num--;
			stopEvent.Set();
		}

		static void Main(string[] args)
		{
			for( int i = 0; i < 30; i++ )
			{
				num++;
				ThreadPool.QueueUserWorkItem( new WaitCallback( DoIt ) );
			}
			do
			{
				stopEvent.WaitOne();
			}while( num > 0 );
			Console.WriteLine( "end" );

			Console.ReadKey();

		}
	}
}
