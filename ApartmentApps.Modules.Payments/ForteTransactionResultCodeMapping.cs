using System.Collections.Generic;

public static class ForteTransactionResultCodeMapping
{
    private static Dictionary<string, ForteTransactionResultCode> _codes;

    public static Dictionary<string, ForteTransactionResultCode> Codes
    {
        get
        {
            if (_codes == null)
            {
                _codes = new Dictionary<string, ForteTransactionResultCode>()
                {
                    { "A01", ForteTransactionResultCode.Approved},
                    { "A03", ForteTransactionResultCode.PartialAuthorization},

                    { "R01", ForteTransactionResultCode.InsufficientFunds},
                    { "R02", ForteTransactionResultCode.AccountClosed},
                    { "R03", ForteTransactionResultCode.NoAccount},
                    { "R04", ForteTransactionResultCode.InvalidAccountNumber},
                    { "R05", ForteTransactionResultCode.PrenoteNotReceived},
                    { "R06", ForteTransactionResultCode.ReturnedPerOdfi},
                    { "R07", ForteTransactionResultCode.AuthorizationRevoked},
                    { "R08", ForteTransactionResultCode.PaymentStopped},
                    { "R09", ForteTransactionResultCode.UncollectedFunds},

                    { "R10", ForteTransactionResultCode.NoAuthorization},
                    { "R11", ForteTransactionResultCode.CheckSafekeepingReturn},
                    { "R12", ForteTransactionResultCode.BranchSold},

                    { "R13", ForteTransactionResultCode.RdfiNotQualified},
                    { "R14", ForteTransactionResultCode.Deceased},
                    { "R15", ForteTransactionResultCode.BeneficiaryDeceased},

                    { "R16", ForteTransactionResultCode.AccountFrozen},
                    { "R20", ForteTransactionResultCode.NonTransactionAccount},
                    { "R23", ForteTransactionResultCode.PaymentRefused},

                    { "R24", ForteTransactionResultCode.DuplicateEntry},
                    { "R26", ForteTransactionResultCode.MandatoryError},
                    { "R28", ForteTransactionResultCode.InvalidTrn},

                    { "R29", ForteTransactionResultCode.CorporateNotAuthorized},

                    { "R31", ForteTransactionResultCode.OdfiPermitsLateReturn},
                    { "R50", ForteTransactionResultCode.InvalidCompanyId},
                    { "R56", ForteTransactionResultCode.InvalidTransactionDate},

                    { "R57", ForteTransactionResultCode.StaleDate},
                    { "R95", ForteTransactionResultCode.OverLimit},
                    { "R96", ForteTransactionResultCode.AccountOnHold},

                    { "R97", ForteTransactionResultCode.RdfiDoesNotParticipate},
                    { "R98", ForteTransactionResultCode.InvalidPassword},
                    { "R99", ForteTransactionResultCode.DeclinedUnpaidItems},

                    { "S01", ForteTransactionResultCode.Funded1},
                    { "S02", ForteTransactionResultCode.Funded2},
                    { "S03", ForteTransactionResultCode.Funded3},

                    { "U01", ForteTransactionResultCode.MerchAuthRevoked},
                    { "U02", ForteTransactionResultCode.TrnOrAccountNotApproved},
                    { "U03", ForteTransactionResultCode.DailyTransLimit},

                    { "U04", ForteTransactionResultCode.MontlyTransLimit},
                    { "U05", ForteTransactionResultCode.AvsFailureZipCode},
                    { "U06", ForteTransactionResultCode.AvsFailureAreaCode},
                    { "U07", ForteTransactionResultCode.AvsFailureEmail},
                    { "U08", ForteTransactionResultCode.DailyVelocity},
                    { "U09", ForteTransactionResultCode.WindowVelocity},
                    { "U10", ForteTransactionResultCode.DuplicateTransaction},
                    { "U11", ForteTransactionResultCode.RecurTransNoFound},
                    { "U12", ForteTransactionResultCode.UpdateNotAllowed},
                    { "U13", ForteTransactionResultCode.OrigTransNotFound},
                    { "U14", ForteTransactionResultCode.BadTypeForOrigTrans},
                    { "U15", ForteTransactionResultCode.AlreadyVoidedOrCaptured},

                    { "U18", ForteTransactionResultCode.UpdateFailed},
                    { "U19", ForteTransactionResultCode.InvalidTrn2},
                    { "U20", ForteTransactionResultCode.InvalidCreditCardNumber},
                    { "U21", ForteTransactionResultCode.BadStartDate},
                    { "U22", ForteTransactionResultCode.SwipeDataFailure},
                    { "U23", ForteTransactionResultCode.InvalidExpirationDate},
                    { "U25", ForteTransactionResultCode.InvalidAmount},
                    { "U26", ForteTransactionResultCode.InvalidData},
                    { "U27", ForteTransactionResultCode.ConvFeeNotAllowed},
                    { "U28", ForteTransactionResultCode.ConvFeeIncorrect},
                    { "U29", ForteTransactionResultCode.ConvFeeDeclined},
                    { "U30", ForteTransactionResultCode.PrincipalDeclined},

                    { "U51", ForteTransactionResultCode.MerchantStatus},
                    { "U52", ForteTransactionResultCode.TypeNotAllowed},
                    { "U53", ForteTransactionResultCode.PerTransLimit},
                    { "U54", ForteTransactionResultCode.InvalidMerchantConfig},
                    { "U80", ForteTransactionResultCode.PreauthDecline},
                    { "U81", ForteTransactionResultCode.PreauthTimeOut},
                    { "U82", ForteTransactionResultCode.PreauthError},
                    { "U83", ForteTransactionResultCode.AuthDecline},
                    { "U84", ForteTransactionResultCode.AuthTimeout},
                    { "U85", ForteTransactionResultCode.AuthError},
                    { "U86", ForteTransactionResultCode.AvsFailureAuth},
                    { "U87", ForteTransactionResultCode.AuthBusy},
                    { "U88", ForteTransactionResultCode.PreAuthBusy},
                    { "U89", ForteTransactionResultCode.AuthUnavailable},
                    { "U90", ForteTransactionResultCode.PreauthUnavailable},
                    { "X02", ForteTransactionResultCode.Voided},
                



                };
            }
            return _codes;
        }
        set { _codes = value; }
    }
}