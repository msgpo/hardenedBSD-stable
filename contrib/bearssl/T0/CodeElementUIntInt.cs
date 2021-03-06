/*
 * Copyright (c) 2016 Thomas Pornin <pornin@bolet.org>
 *
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to
 * permit persons to whom the Software is furnished to do so, subject to
 * the following conditions:
 *
 * The above copyright notice and this permission notice shall be 
 * included in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND 
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
 * BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
 * ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;

class CodeElementUIntInt : CodeElement {

	uint val1;
	int val2;

	internal CodeElementUIntInt(uint val1, int val2) : base()
	{
		this.val1 = val1;
		this.val2 = val2;
	}

	/* obsolete
	internal override int Length {
		get {
			return Encode7EUnsigned(val1, null)
				+ Encode7ESigned(val2, null);
		}
	}
	*/

	internal override int GetLength(bool oneByteCode)
	{
		return (oneByteCode ? 1 : Encode7EUnsigned(val1, null))
			+ Encode7ESigned(val2, null);
	}

	internal override int Encode(BlobWriter bw, bool oneByteCode)
	{
		int len = oneByteCode
			? EncodeOneByte(val1, bw)
			: Encode7EUnsigned(val1, bw);
		len += Encode7ESigned(val2, bw);
		return len;
	}
}
