# IntroJS

[IntroJS](http://introjs.com/) is a JavaScript tool to create hints and intro, or tutorial steps to our website. It's very easy to use and working on mobiles too.

## Setting up IntroJS

Since the JavaScript library supports many themes, we have to include them before using the extension. We can do this with a simple `[<Require()>]`:

```fsharp
    [<Require(typeof<WebSharper.IntroJS.Resources.MainTheme>)>]
    [<SPAEntryPoint>]
    let Main () =
        ...
```

*This MainTheme is required at every instance.*

## Themes

To add a new theme, we just have to add another `[<Require()>]` after the MainTheme like this:

```fsharp
    [<Require(typeof<WebSharper.IntroJS.Resources.MainTheme>)>]
    [<Require(typeof<WebSharper.IntroJS.Resources.ModernTheme>)>]
    [<SPAEntryPoint>]
    let Main () =
```

Note: It's important to add the theme after the MainTheme so it would overwrite the corrent css.

## Setting up intros

We can use the same way to do it as it's done in the original IntroJS:

* placing `data-step` and `data-intro` in the html file
* with the `IntroJs().AddSteps()` function

## Differences in the bind

To configure IntroJS or to add new steps JavaScript uses simple objects, but in the bind we have classes for those configurations.

For example in JavaScript:

```javascript
introJs().addStep({
    element: document.querySelectorAll('#step2')[0],
    intro: "Ok, wasn't that fun?",
    position: 'right'
});
```

This would work like this in WebSharper:

```fsharp
IntroJs().AddStep(new StepConfig(
    Element = JS.Document.QuerySelectorAll("#step2").[0],
    Intro = "Ok, wasn't that fun?",
    Position = "right"
))
```

The same pattern goes for every object like this.