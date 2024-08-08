using System.Text.RegularExpressions;
using SupplierService.Domain.Errors;
using SupplierService.Domain.Shared;

namespace SupplierService.Domain.ValueObjects;

public sealed class Email
{
	private const int MaxLength = 256;
	private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
	private static readonly Lazy<Regex> EmailFormatRegex =
		new(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

	/// <summary>
	/// Initializes a new instance of the <see cref="Email"/> class.
	/// </summary>
	/// <param name="value">The email value.</param>
	private Email(string value)
	{
		Value = value;
	}

	/// <summary>
	/// Gets the email value.
	/// </summary>
	public string Value { get; private set; }

	public static implicit operator string(Email email) => email.Value;

	public static Result<Email> Create(string email)
	{
		if (string.IsNullOrWhiteSpace(email))
		{
			return Result.Failure<Email>(DomainErrors.Email.NullOrEmpty);
		}

		if (email.Length > MaxLength)
		{
			return Result.Failure<Email>(DomainErrors.Email.LongerThanAllowed);
		}

		if (EmailFormatRegex.Value.IsMatch(email))
		{
			return Result.Failure<Email>(DomainErrors.Email.InvalidFormat);
		}

		return new Email(email);
	}
}
