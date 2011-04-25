Snappy, a fast compressor/decompressor.


Introduction
============

Snappy is a compression/decompression library. It does not aim for maximum
compression, or compatibility with any other compression library; instead,
it aims for very high speeds and reasonable compression. For instance,
compared to the fastest mode of zlib, Snappy is an order of magnitude faster
for most inputs, but the resulting compressed files are anywhere from 20% to
100% bigger. (For more information, see "Performance", below.)

Snappy has the following properties:

 * Fast: Compression speeds at 250 MB/sec and beyond, with no assembler code.
   See "Performance" below.
 * Stable: Over the last few years, Snappy has compressed and decompressed
   petabytes of data in Google's production environment. The Snappy bitstream
   format is stable and will not change between versions.
 * Robust: The Snappy decompressor is designed not to crash in the face of
   corrupted or malicious input.
 * Free and open source software: Snappy is licensed under a BSD-type license.
   For more information, see the included COPYING file.

Snappy has previously been called "Zippy" in some Google presentations
and the like.


Performance
===========
 
Snappy is intended to be fast. On a single core of a Core i7 processor
in 64-bit mode, it compresses at about 250 MB/sec or more and decompresses at
about 500 MB/sec or more. (These numbers are for the slowest inputs in our
benchmark suite; others are much faster.) In our tests, Snappy usually
is faster than algorithms in the same class (e.g. LZO, LZF, FastLZ, QuickLZ,
etc.) while achieving comparable compression ratios.

Typical compression ratios (based on the benchmark suite) are about 1.5-1.7x
for plain text, about 2-4x for HTML, and of course 1.0x for JPEGs, PNGs and
other already-compressed data. Similar numbers for zlib in its fastest mode
are 2.6-2.8x, 3-7x and 1.0x, respectively. More sophisticated algorithms are
capable of achieving yet higher compression rates, although usually at the
expense of speed. Of course, compression ratio will vary significantly with
the input.

Although Snappy should be fairly portable, it is primarily optimized
for 64-bit x86-compatible processors, and may run slower in other environments.
In particular:

 - Snappy uses 64-bit operations in several places to process more data at
   once than would otherwise be possible.
 - Snappy assumes unaligned 32- and 64-bit loads and stores are cheap.
   On some platforms, these must be emulated with single-byte loads 
   and stores, which is much slower.
 - Snappy assumes little-endian throughout, and needs to byte-swap data in
   several places if running on a big-endian platform.

Experience has shown that even heavily tuned code can be improved.
Performance optimizations, whether for 64-bit x86 or other platforms,
are of course most welcome; see "Contact", below.


Usage
=====

Note that Snappy, both the implementation and the main interface,
is written in C++. However, several third-party bindings to other languages
are available; see the Google Code page at http://code.google.com/p/snappy/
for more information. Also, if you want to use Snappy from C code, you can
use the included C bindings in snappy-c.h.

To use Snappy from your own C++ program, include the file "snappy.h" from
your calling file, and link against the compiled library.

There are many ways to call Snappy, but the simplest possible is

  SnappySharp.Api.Compress (input, ref output);

and similarly

  SnappySharp.Api.Uncompress (input, ref output);

where "input" and "output" are both instances of string.

There are other interfaces that are more flexible in various ways, including
support for custom (non-array) input sources. See the header file for more
information.