This repository is part of the [🌸🗡️ Sakura Framework](https://github.com/HelloYeew/sakura) ecosystem.

---

# Sakura Framework Icon Generator

A script to generate the "IconUsage" class related to make the icon library usable in IconSprite by reading the codepoint file of the icon library and generate the `uint` constant for each icon in the library.

## Icon library list

Since Sakura Framework is open-source. Icon we use must be open-source or have a license that allows us to use it in an open-source project.

- [Material Symbols](https://fonts.google.com/icons) ([Repository](https://github.com/google/material-design-icons/tree/master/variablefont))

## Generating the icon class

- Grab the codepoint file of the icon library repository and put it in `Fonts` folder.
- Run the program
- Grab the `IconUsage.cs` file in the output folder and put it in `Sakura.Framework.Drawables`

## License

This extension is part of the Sakura Framework, see [the main repository](https://github.com/HelloYeew/sakura) for more information.

This project is licensed under the MIT license. Please see [the license file](LICENSE) for more information. tl;dr you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.

Material Symbols are licensed under the [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0).