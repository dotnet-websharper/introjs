# WebSharper.IntroJS

WebSharper Extension for introjs **7.2.0**

## Installation

Add **Intro.js** to your project using npm:

```bash
npm install intro.js
```

Add the **WebSharper.IntroJS** NuGet package to your F# project.

## Usage

### Import IntroJS

```fsharp
open WebSharper.IntroJS

let intro = new IntroJs()
```

### Load the styles
Import the CSS using the `Styles` Class:

```fsharp
open WebSharper.IntroJS

// Load the core style
Styles.Main()

// Optional: use RTL or theme styles
Styles.RTL()
Styles.Dark()
Styles.Modern()
Styles.Flattener()
Styles.Nassim()
Styles.Nazanin()
Styles.Royal()
```

These calls ensure the appropriate .css files are imported when building your WebSharper app.

## Documentation

See the [Intro.js](https://introjs.com/docs) docs for detailed usage examples.