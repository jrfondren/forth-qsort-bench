# Forth qsort benchmark
In Forth, generic code is usually generic by way of a vectored word. In this
case, a vectored-generic QSORT allows the caller, on each call, to change the
meaning of the word PRECEDES that QSORT itself calls. This is similar to
passing a function pointer to QSORT, or to passing it an object with a
late-bound method.

Another way to get generic code in Forth is to compile the code multiple times
with the code's dependent words defined for it. This is more similar to a
parameterized module in a language like OCaml, and an advantage of this
technique for Forth is that it allows for better optimization of each version
of QSORT

The optimization benefit probably won't be seen without an optimizer.

## build
```
$ make        # build a default rand.int blob

$ make MB=30  # build a 30 MB rand.int blob

$ make clean  # delete rand.int
```

## benchmark examples
```
iforth: QSORT with vectored PRECEDES
$ iforth warning off include randints.fs include vectored.fs include qsort.fs include bench.fs bye

iforth: QSORT with a fixed PRECEDES
$ iforth include randints.fs include fixed.fs include qsort.fs include bench.fs bye

gforth without [timer-reset et al.](http://src.minimaltype.com/timer.cgi/index)
$ time gforth randints.fs fixed.fs qsort.fs -e 'rand.int sort bye'

if you want see the numbers...
$ iforth include randints.fs include fixed.fs include qsort.fs include bench.fs .rand.int bye
```

## timings, average of 3 runs
| Version  | rand.int | Time    |
|----------|----------|---------|
| vectored |     4 MB |  106 ms |
| fixed    |     4 MB |   68 ms |
|----------|----------|---------|
| vectored |    30 MB |  912 ms |
| fixed    |    30 MB |  552 ms |
|----------|----------|---------|
| vectored |   100 MB | 3170 ms |
| fixed    |   100 MB | 1984 ms |
