// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Fixtures.AcceptanceTestsBodyDateTime
{
    using System.Threading.Tasks;
   using Models;

    /// <summary>
    /// Extension methods for Datetime.
    /// </summary>
    public static partial class DatetimeExtensions
    {
            /// <summary>
            /// Get null datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetNull(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetNullAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get null datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetNullAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetNullWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get invalid datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetInvalid(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetInvalidAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get invalid datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetInvalidAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetInvalidWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get overflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetOverflow(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetOverflowAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get overflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetOverflowAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetOverflowWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get underflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUnderflow(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetUnderflowAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get underflow datetime value
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetUnderflowAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetUnderflowWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put max datetime value 9999-12-31T23:59:59.9999999Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutUtcMaxDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutUtcMaxDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put max datetime value 9999-12-31T23:59:59.9999999Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutUtcMaxDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutUtcMaxDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get max datetime value 9999-12-31t23:59:59.9999999z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcLowercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetUtcLowercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value 9999-12-31t23:59:59.9999999z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetUtcLowercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetUtcLowercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get max datetime value 9999-12-31T23:59:59.9999999Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcUppercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetUtcUppercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value 9999-12-31T23:59:59.9999999Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetUtcUppercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetUtcUppercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put max datetime value with positive numoffset
            /// 9999-12-31t23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutLocalPositiveOffsetMaxDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutLocalPositiveOffsetMaxDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put max datetime value with positive numoffset
            /// 9999-12-31t23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutLocalPositiveOffsetMaxDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutLocalPositiveOffsetMaxDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31t23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalPositiveOffsetLowercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31t23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalPositiveOffsetLowercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalPositiveOffsetLowercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31T23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalPositiveOffsetUppercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31T23:59:59.9999999+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalPositiveOffsetUppercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalPositiveOffsetUppercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put max datetime value with positive numoffset
            /// 9999-12-31t23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutLocalNegativeOffsetMaxDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutLocalNegativeOffsetMaxDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put max datetime value with positive numoffset
            /// 9999-12-31t23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutLocalNegativeOffsetMaxDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutLocalNegativeOffsetMaxDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31T23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalNegativeOffsetUppercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31T23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalNegativeOffsetUppercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalNegativeOffsetUppercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31t23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalNegativeOffsetLowercaseMaxDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get max datetime value with positive num offset
            /// 9999-12-31t23:59:59.9999999-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalNegativeOffsetLowercaseMaxDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalNegativeOffsetLowercaseMaxDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutUtcMinDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutUtcMinDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutUtcMinDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutUtcMinDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetUtcMinDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetUtcMinDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00Z
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetUtcMinDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetUtcMinDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutLocalPositiveOffsetMinDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutLocalPositiveOffsetMinDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutLocalPositiveOffsetMinDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutLocalPositiveOffsetMinDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalPositiveOffsetMinDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalPositiveOffsetMinDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00+14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalPositiveOffsetMinDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalPositiveOffsetMinDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            public static void PutLocalNegativeOffsetMinDateTime(this IDatetime operations, System.DateTime datetimeBody)
            {
                System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).PutLocalNegativeOffsetMinDateTimeAsync(datetimeBody), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None,  System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Put min datetime value 0001-01-01T00:00:00-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='datetimeBody'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task PutLocalNegativeOffsetMinDateTimeAsync(this IDatetime operations, System.DateTime datetimeBody, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                await operations.PutLocalNegativeOffsetMinDateTimeWithHttpMessagesAsync(datetimeBody, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static System.DateTime? GetLocalNegativeOffsetMinDateTime(this IDatetime operations)
            {
                return System.Threading.Tasks.Task.Factory.StartNew(s => ((IDatetime)s).GetLocalNegativeOffsetMinDateTimeAsync(), operations, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskCreationOptions.None, System.Threading.Tasks.TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get min datetime value 0001-01-01T00:00:00-14:00
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async System.Threading.Tasks.Task<System.DateTime?> GetLocalNegativeOffsetMinDateTimeAsync(this IDatetime operations, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
            {
                using (var _result = await operations.GetLocalNegativeOffsetMinDateTimeWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
