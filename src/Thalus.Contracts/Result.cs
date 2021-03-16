using System;
using System.Text;

namespace Thalus.Contracts
{
    public class Result : IResult
    {
        public bool Success { get; set; }

        public int Code { get; set; }

        public object Data { get; set; }

        public TextDTO Text { get; set; }

        IText IProvideText.GetText() { return new TextDTO(Text); }

        public TType GetData<TType>() where TType : class
        {
            if (Data == null)
            {
                return default(TType);
            }

            var tp = typeof(TType);
            Type dataType = Data.GetType();

            var item = Data as TType;

            if (item != null)
            {
                return item;
            }

            throw new InvalidCastException($"Unable to cast DataType={dataType} to TType={tp }");
        }

        public IError GetError()
        {
            return new ErrorDTO { Code = Code, Data = Data, Text = new TextDTO(Text) };
        }

        public static IResult Exception(Exception data, IText text = null)
        {
            return Exception(data, text?.Invariant, text?.Localized, text?.Locale);
        }

        public static IResult Exception(Exception data, string invariant, string localized = "Result failed", string locale = "en-US")
        {
            return new Result
            {
                Code = 500,
                Text = new TextDTO
                {
                    Encoding = nameof(Encoding.UTF8),
                    Locale = locale,
                    Invariant = invariant,
                    Localized = localized
                },
                Data = data,
                Success = false
            };
        }

        public static IResult<TType> Exception<TType>(Exception data, string invariant, string localized = "Result failed", string locale = "en-US")
        {
            return new Result<TType>
            {
                Code = 500,
                Text = new TextDTO
                {
                    Encoding = nameof(Encoding.UTF8),
                    Locale = locale,
                    Invariant = invariant,
                    Localized = localized
                },
                Data = data,
                Success = false
            };
        }

        public static IResult Fail(int code, IText text = null, object data = null)
        {
            return Fail(code, text?.Invariant, text?.Localized, text?.Locale, data);
        }

        public static IResult Fail(int code, string invariant, string localized = "Result failed", string locale = "en-US", object data = null)
        {
            return new Result
            {
                Code = code,
                Text = new TextDTO
                {
                    Encoding = nameof(Encoding.UTF8),
                    Locale = locale,
                    Invariant = invariant,
                    Localized = localized
                }
                ,
                Data = data,
                Success = false,
            };
        }

        public static IResult Ok(IText text, int code = StatusCode.OK, object data = null)
        {
            return Ok(code, text?.Invariant, text?.Localized, text?.Locale, data);
        }

        public static IResult<TType> Ok<TType>(TType data, IText text = null, int code = StatusCode.OK)
        {
            return Ok<TType>(code, text?.Invariant, text?.Localized, text?.Locale, data);
        }

        public static IResult Ok(int code = StatusCode.OK, string invariant = "Result successful", string localized = "Result successful", string locale = "en-US", object data = null)
        {
            return new Result
            {
                Code = code,
                Text = new TextDTO
                {
                    Encoding = nameof(Encoding.UTF8),
                    Locale = locale,
                    Invariant = invariant,
                    Localized = localized
                }
                ,
                Data = data,
                Success = true
            };
        }

        public static IResult<TType> Ok<TType>(int code = StatusCode.OK, string invariant = "Result successful", string localized = "Result successful", string locale = "en-US", object data = null)
        {
            return new Result<TType>
            {
                Code = code,
                Text = new TextDTO
                {
                    Encoding = nameof(Encoding.UTF8),
                    Locale = locale,
                    Invariant = invariant,
                    Localized = localized
                }
                ,
                Data = data,
                Success = true
            };
        }
    }


    public class Result<TType> : Result, IResult<TType>
    {
        public TType ResultSet
        {
            get
            {
                return Success ? (TType)Data : default(TType);
            }
        }

        public void ThrowIfException()
        {
            if (Success)
            {
                return;
            }

            var error = this.GetError();
            if (error.IsException)
            {
                throw error.Exception;
            }
        }
    }
}


