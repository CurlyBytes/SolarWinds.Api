using System;
using Xunit;
using Xunit.Abstractions;

namespace SolarWinds.Api.Test
{
	public class SolarWindsClientConstructorTests : TestWithOutput
	{
		public SolarWindsClientConstructorTests(ITestOutputHelper iTestOutputHelper) : base(iTestOutputHelper)
		{
		}

		/// <summary>
		/// Null parameters should throw an appropriate exception
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		[Theory]
		[InlineData(null, "username", "password")]
		[InlineData("hostname", null, "password")]
		[InlineData("hostname", "username", null)]
		public void MissingParameters_Throws_ArgumentNullException(string hostname, string username, string password)
			=> Assert.Throws<ArgumentNullException>(() => new SolarWindsClient(hostname, username, password));

		/// <summary>
		/// Empty parameters should throw an appropriate exception
		/// </summary>
		/// <param name="hostname"></param>
		/// <param name="username"></param>
		/// <param name="password"></param>
		[Theory]
		[InlineData("", "username", "password")]
		[InlineData("hostname", "", "password")]
		[InlineData("hostname", "username", "")]
		public void EmptyParameters_Throws_ArgumentOutOfRangeException(string hostname, string username, string password)
			=> Assert.Throws<ArgumentOutOfRangeException>(() => new SolarWindsClient(hostname, username, password));
	}
}
