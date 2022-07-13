﻿using BenchmarkDotNet.Attributes;

namespace Homework12
{
	public class HostBuilderCSharp : WebApplicationFactory<Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<Startup>()
					.UseTestServer());
	}
	
	public class HostBuilderFSharp : WebApplicationFactory<App.Startup>
	{
		protected override IHostBuilder CreateHostBuilder()
			=> Host
				.CreateDefaultBuilder()
				.ConfigureWebHostDefaults(a => a
					.UseStartup<App.Startup>()
					.UseTestServer());
	}
	
	[MaxColumn]
	[MinColumn]
	public class WebTests
	{
		private HttpClient _cSharpClient;
		private HttpClient _fSharpClient;
		
		[GlobalSetup]
		public void SetUp()
		{
			_cSharpClient =  new HostBuilderCSharp().CreateClient();
			_fSharpClient =  new HostBuilderFSharp().CreateClient();
		}
		
		[Benchmark]
		public async Task HundredPlusTwoHundredCSharp()
		{
			await SendRequestCSharp("1", "Add", "2");
		}
		
		
		[Benchmark]
		public async Task HundredPlusTwoHundredFSharp()
		{
			await SendRequestFSharp("1", "plus", "2");
		}
		
		[Benchmark]
		public async Task ThreeMinusTwoCSharp()
		{
			await SendRequestCSharp("3", "Subtract", "2");
		}
		
		
		[Benchmark]
		public async Task ThreeMinusTwoFSharp()
		{
			await SendRequestFSharp("3", "minus", "2");
		}
		
		[Benchmark]
		public async Task TenMultiplyThreeCSharp()
		{
			await SendRequestCSharp("10", "Multiply", "3");
		}
		
		
		[Benchmark]
		public async Task TenMultiplyThreeFSharp()
		{
			await SendRequestFSharp("3", "mult", "2");
		}
		
		[Benchmark]
		public async Task TwentyDivideTenCSharp()
		{
			await SendRequestCSharp("20", "Divide", "10");
		}
		
		
		[Benchmark]
		public async Task TwentyDivideTenFSharp()
		{
			await SendRequestFSharp("20", "divide", "10");
		}

		private async Task SendRequestCSharp(string v1, string operation, string v2)
		{
			await _cSharpClient.GetAsync($"https://localhost:5001/Calculator/{operation}?val1={v1}&val2={v2}");
		}
		
		private async Task SendRequestFSharp(string v1, string operation, string v2)
		{
			await _fSharpClient.GetAsync($"http://localhost:5000/calculate?v1={v1}&Operation={operation}&v2={v2}");
		}
	}
}