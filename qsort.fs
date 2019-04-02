\ Hoare's Quicksort via Wil Baden via comp.lang.forth

-1 CELLS CONSTANT -CELL
: CELL-  POSTPONE -CELL  POSTPONE + ; IMMEDIATE

: QUICK  ( a[m],a[n] -- )                       ( partition a[m]..a[n] )
    2DUP  OVER - 1 RSHIFT -CELL AND + @ >R   ( take middle value as pivot )
    2DUP SWAP
    BEGIN           ( m,n,j,i )                 ( m <= i <= j <= n )
        BEGIN  DUP @  R@  PRECEDES  WHILE  CELL+  REPEAT  SWAP
        BEGIN  R@ OVER @  PRECEDES  WHILE  CELL-  REPEAT  SWAP
        2DUP U< 0=
        IF  2DUP 2DUP @ >R  @ SWAP !  R> SWAP !  SWAP CELL- SWAP CELL+ THEN
        2DUP U<
    UNTIL  R> DROP  ( m,n,j,i )                 ( a <= j < i <= n )
    ROT  ( i,j,i,n )  2OVER 2OVER  - + > IF  2SWAP  ( i,n,m,j )  THEN
    2DUP U<  IF  RECURSE  ELSE  2DROP  THEN     ( shorter part )
    2DUP U<  IF  RECURSE  ELSE  2DROP  THEN     ( longer part )  ;

: SORT  ( a,n -- )              ( order a[0]..a[n-1] by "PRECEDES". )
    ?DUP 0= ABORT" nothing to sort."
    1- CELLS OVER +  ( a[0],a[n-1] )  QUICK ;
