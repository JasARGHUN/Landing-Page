using LandingPageTemplate.Client.Auth;
using System;
using System.Timers;

namespace NewsProject.Client.Auth
{
    public class TokenRenewer : IDisposable
    {
        private readonly ILoginService loginService;
        Timer timer;
        public TokenRenewer(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        public void Initiate()
        {
            timer = new Timer();
            timer.Interval = 1000 * 60 * 4; // 4 minutes
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            loginService.TryRenewToken();
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
