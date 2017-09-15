﻿using RedactSharp.Validators;

namespace RedactSharp.Redactors.CreditCard
{
    public class DiscoverRedactor : AbstractRedactor, IRedactConfigurable<AbstractRedactor, IRedactorOptions>
    {
        public CreditCardRedactorOptions Options { get; set; }

        public DiscoverRedactor()
        {
            UseValidator<LuhnValidator>();
            UseMatchProcessor<CreditCardMatchProcessor>();
            UseSanitizer<CreditCardSanitizer>();
            UseExpressionMatcher<RegularExpressionMatcher>(@"((6011|65\d{2}|64[4-9]\d)\d{12}|(62\d{14}))");
            UseFriendlyName("Discover");
        }

        public AbstractRedactor Configure(IRedactorOptions options)
        {
            Options = (CreditCardRedactorOptions)options;

            return this;
        }

        public IRedactorOptions GetConfiguration()
        {
            return Options;
        }
    }
}