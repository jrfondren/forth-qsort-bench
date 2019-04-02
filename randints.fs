4 constant rand.int.MB  \ number edited by sed in Makefile

rand.int.MB 1024 * 1024 * constant /randint

/randint allocate throw constant 'rand.int

s" rand.int" r/o open-file throw
dup 'rand.int /randint rot read-file throw /randint <> [if] .( rand.int too small) abort [then]
close-file throw

'rand.int /randint 1 cells / 2constant rand.int

: .rand.int ( -- )
   'rand.int /randint bounds do
      cr i ?
   1 cells +loop ;
