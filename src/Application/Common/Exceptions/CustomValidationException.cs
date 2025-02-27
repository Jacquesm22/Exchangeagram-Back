﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeAGram.Application.Common.Exceptions
{
    public class CustomValidationException : Exception
    {
        public CustomValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
