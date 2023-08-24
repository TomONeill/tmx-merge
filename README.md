# TMX tileset deduplicator

Using Tiled and have duplicate tilesets you want to consolidate back into one? This is the application for you.

> Usage notes: it is NOT possible at this moment in time to integrate this executable as a command in Tiled itself.
> This is a standalone executable that should be used separately from Tiled.

## Usage

Run the project/executable. The location of the .tmx file is being asked for.
Then the tilesets in the .tmx file will be listed and can be selected to mark for deduplication. After that, tilesets will be consolidated and the duplicate tilesets will be removed. A new .tmx file is created in the same directory as the source.

## When to use

If you have duplicate tilesets, used tiles from either tileset and now want to consolidate the tilesets into 1 tileset, keeping the used tiles from both tilesets.

## How was the duplicate tileset created?

It's possible that you copied tiles from another .tmx file, causing a duplicate tileset into the tmx file you're copying to, even if the exact same tileset was already there.

# Releases

<A HREF="https://github.com/TomONeill/tmx-tileset-deduplicator/releases">Releases</A>

# Donate

If you like my work so much that you feel like doing something nice for me, a complete stranger of the internet, you can.<BR />
<A HREF="https://www.paypal.me/TomONeill">Donate here</A>.
