﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RestEase
{
    /// <summary>
    /// Delegate used to modify outgoing HttpRequestMessages
    /// </summary>
    /// <param name="request">Request to modify</param>
    /// <param name="cancellationToken">CancellationToken to abort this request</param>
    /// <returns>A task which completes when modification has occurred</returns>
    public delegate Task RequestModifier(HttpRequestMessage request, CancellationToken cancellationToken);
}
