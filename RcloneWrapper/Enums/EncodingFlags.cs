/*
    https://github.com/rclone/rclone/blob/master/lib/encoder/encoder.go
*/

using System;

namespace RcloneWrapper.Enums
{
    [Flags]
    public enum EncodingFlags : int
    {
        /// <summary>
        /// NUL(0x00)
        /// </summary>
        Zero = 0,

        /// <summary>
        /// /
        /// </summary>
        Slash = 1 << 0,

        /// <summary>
        /// &lt;&gt;
        /// </summary>
        LtGt = 1 << 2,

        /// <summary>
        /// "
        /// </summary>
        DoubleQuote = 1 << 3,

        /// <summary>
        /// '
        /// </summary>
        SingleQuote = 1 << 4,

        /// <summary>
        /// `
        /// </summary>
        BackQuote = 1 << 5,

        /// <summary>
        /// $
        /// </summary>
        Dollar = 1 << 6,

        /// <summary>
        /// :
        /// </summary>
        Colon = 1 << 7,

        /// <summary>
        /// ?
        /// </summary
        Question = 1 << 8,

        /// <summary>
        /// *
        /// </summary>
        Asterisk = 1 << 9,

        /// <summary>
        /// |
        /// </summary>
        Pipe = 1 << 10,

        /// <summary>
        /// #
        /// </summary
        Hash = 1 << 11,

        /// <summary>
        /// %
        /// </summary>
        Percent = 1 << 12,

        /// <summary>
        /// \
        /// </summary
        BackSlash = 1 << 13,

        /// <summary>
        /// CR(0x0D), LF(0x0A)
        /// </summary>
        CrLf = 1 << 14,

        /// <summary>
        /// DEL(0x7F)
        /// </summary
        Del = 1 << 15,

        /// <summary>
        /// CTRL(0x01-0x1F)
        /// </summary>
        Ctl = 1 << 16,

        /// <summary>
        /// Leading SPACE
        /// </summary>
        LeftSpace = 1 << 17,

        /// <summary>
        /// Leading .
        /// </summary>
        LeftPeriod = 1 << 18,

        /// <summary>
        /// Leading ~
        /// </summary
        LeftTilde = 1 << 19,

        /// <summary>
        /// Leading CR LF HT VT
        /// </summary>
        LeftCrLfHtVt = 1 << 20,

        /// <summary>
        /// Trailing SPACE
        /// </summary
        RightSpace = 1 << 21,

        /// <summary>
        /// Trailing .
        /// </summary
        RightPeriod = 1 << 22,

        /// <summary>
        /// Trailing CR LF HT VT
        /// </summary
        RightCrLfHtVt = 1 << 23,

        /// <summary>
        /// Invalid UTF-8 bytes
        /// </summary
        InvalidUtf8 = 1 << 24,

        /// <summary>
        /// . and .. names
        /// </summary>
        Dot = 1 << 25,

        /// <summary>
        /// []
        /// </summary
        SquareBracket = 1 << 26,

        /// <summary>
        /// ;
        /// </summary
        Semicolon = 1 << 27,

        /// <summary>
        /// :?"*&lt;&gt;|
        /// </summary>
        Win = Colon | Question | DoubleQuote | Asterisk | LtGt | Pipe,

        /// <summary>
        /// #%
        /// </summary>
        HashPercent = Hash | Percent
    }
}
