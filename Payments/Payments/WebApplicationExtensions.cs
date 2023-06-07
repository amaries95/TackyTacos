using Microsoft.AspNetCore.Builder;
using Payments.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payments
{
    public static class WebApplicationExtensions
    {
        public static WebApplication AddPaymentEndpoints(this WebApplication app)
        {
            app.MapPaymentEndpoints();
            return app;
        }
    }
}
