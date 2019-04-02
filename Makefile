MB=4

rand.int:
	dd if=/dev/urandom of=$@ bs=1024 count=$$(($(MB) * 1024))
	perl -i -pe 's/^\d* constant rand.int.MB /$(MB) constant rand.int.MB /' randints.fs

clean::
	rm -fv rand.int
