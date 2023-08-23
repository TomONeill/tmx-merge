- find out why there are values in layers that exceed the int max value

- improve selector:

  - only list tilesets which have equal counts of other tileset
  - only allow selection of tilesets that have equal counts
  - prevent selecting only one tileset

- write unit test for example tmx
- add `--force` option to ignore layers that contain data that can't be processed (other data types than csv)
- Add `--verbose` option
