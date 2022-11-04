using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders
{
    public interface IOptionsBuilder
    {
        /// <summary>
        /// Custom options not defined in this class. Keys without a value are treated as <see cref="bool"/>
        /// </summary>
        Dictionary<string, string> CustomOptions { get; set; }

        /// <summary>
        /// Adds a custom option not defined anywhere else
        /// </summary>
        /// <param name="flag">Use the full flag. Example: --temp-dir</param>
        /// <param name="value">If null, the flag will be treated as a <see cref="bool"/></param>
        void AddCustomOption(string flag, string value);

        /// <summary>
		/// Add a custom bool to <see cref="CustomOptions"/>
		/// </summary>
		/// <param name="flag">Use the full flag. Eg: --my-flag</param>
		void AddCustomOption(string flag, bool value, bool defaultValue = false);

        /// <summary>
        /// Add a custom tristate (true,false,unset) to <see cref="CustomOptions"/>
        /// </summary>
        /// <param name="flag">Use the full flag. Eg: --my-flag</param>
        void AddCustomOption(string flag, bool? value, bool? defaultValue = null);

        /// <summary>
        /// Add a custom duration to <see cref="CustomOptions"/>
        /// </summary>
        /// <param name="flag">Use the full flag. Eg: --my-flag</param>
        void AddCustomOption(string flag, TimeSpan? value);

        /// <summary>
        /// Add a custom SizeSuffix to <see cref="CustomOptions"/>
        /// </summary>
        /// <param name="flag">Use the full flag. Eg: --my-flag</param>
        /// <param name="sizeSuffix"></param>
        void AddCustomOption(string flag, SizeSuffix sizeSuffix);

        /// <summary>
        /// Add a custom int to <see cref="CustomOptions"/>
        /// </summary>
		/// <param name="flag">Use the full flag. Eg: --my-flag</param>
        void AddCustomOption(string flag, int? value);

        /// <summary>
        /// Add a custom uint to <see cref="CustomOptions"/>
        /// </summary>
        /// <param name="flag">Use the full flag. Eg: --my-flag</param>
        void AddCustomOption(string flag, uint? value);

        /// <summary>
        /// Build the command line arguments
        /// </summary>
        string BuildArgs();
    }
}
