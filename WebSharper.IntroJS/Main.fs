// $begin{copyright}
//
// This file is part of WebSharper
//
// Copyright (c) 2008-2018 IntelliFactory
//
// Licensed under the Apache License, Version 2.0 (the "License"); you
// may not use this file except in compliance with the License.  You may
// obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
// implied.  See the License for the specific language governing
// permissions and limitations under the License.
//
// $end{copyright}
namespace WebSharper.IntroJS.Extension

open WebSharper
open WebSharper.JavaScript
open WebSharper.InterfaceGenerator

module Definition =

    let Styles = Class "Styles"

    let StepConfigClass =
        Pattern.Config "StepConfig" {
            Required = []
            Optional = [
                "step", T<int>
                "title", T<string>
                "intro", T<string>
                "position", T<string>
                "scrollTo", T<string>
                "tooltipClass", T<string>
                "highlightClass", T<string>
                "element", T<Dom.Element> + T<string> + T<obj>
                "disableInteraction", T<bool>
            ]
        }

    let HintConfigClass =
        Pattern.Config "HintConfig" {
            Required = []
            Optional = [
                "position", T<string>
                "hintPosition", T<string>
                "element", T<Dom.Element> + T<string> + T<obj>
                "tooltipClass", T<string>
                "hint", T<string>
                "hintTargetElement", T<Dom.Element>
                "hintAnimation", T<bool>
            ]
        }

    let OptionsClass =
        Pattern.Config "Options" {
            Required = []
            Optional =
                [
                    "steps", !| StepConfigClass.Type
                    "hints", !| HintConfigClass.Type
                    "isActive", T<bool>
                    "nextLabel", T<string>
                    "prevLabel", T<string>
                    "skipLabel", T<string>
                    "doneLabel", T<string>
                    "hidePrev", T<bool>
                    "hideNext", T<bool>
                    "nextToDone", T<bool>
                    "tooltipPosition", T<string>
                    "tooltipClass", T<string>
                    "group", T<string>
                    "highlightClass", T<string>
                    "exitOnEsc", T<bool>
                    "exitOnOverlayClick", T<bool>
                    "showStepNumbers", T<bool>
                    "stepNumbersOfLabel", T<string>
                    "keyboardNavigation", T<bool>
                    "showButtons", T<bool>
                    "showBullets", T<bool>
                    "showProgress", T<bool>
                    "scrollToElement", T<bool>
                    "scrollTo", T<string>
                    "scrollPadding", T<int>
                    "overlayOpacity", T<float>
                    "autoPosition", T<bool>
                    "positionPrecedence", !| T<string>
                    "disableInteraction", T<bool>
                    "dontShowAgain", T<bool>
                    "dontShowAgainLabel", T<string>
                    "dontShowAgainCookie", T<string>
                    "dontShowAgainCookieDays", T<int>
                    "helperElementPadding", T<int>
                    "hintPosition", T<string>
                    "hintButtonLabel", T<string>
                    "hintShowButton", T<bool>
                    "hintAutoRefreshInterval", T<int>
                    "hintAnimation", T<bool>
                    "buttonClass", T<string>
                    "progressBarAdditionalClass", T<bool>
                ]
        }

    let IntroJSClass =
        Class "introJs"
        |> ImportDefault "intro.js/intro.js"
        |+> Static [
            Constructor (!? T<HTMLElement>)
        ]
        |+> Instance [
            "isActive" => T<unit> ^-> T<bool>

            "clone" => T<unit> ^-> TSelf

            "setOption" => T<string> * T<obj> ^-> TSelf

            "setOptions" => T<obj> ^-> TSelf

            "start" => T<unit> ^-> T<Promise<_>>[TSelf]

            "goToStep" => T<int> ^-> T<Promise<_>>[TSelf]

            "addStep" => StepConfigClass.Type ^-> T<unit>

            "addSteps" => !| StepConfigClass.Type ^-> T<unit>

            "goToStepNumber" => T<int> ^-> T<Promise<_>>[TSelf]

            "nextStep" => T<unit> ^-> T<Promise<_>>[TSelf]

            "previousStep" => T<unit> ^-> T<Promise<_>>[TSelf]

            "currentStep" => T<unit> ^-> T<int>

            "exit" => T<bool> ^-> T<Promise<_>>[TSelf]

            "refresh" => T<unit> ^-> TSelf

            "setDontShowAgain" => T<bool> ^-> TSelf

            "onbeforechange" => T<Function> ^-> TSelf

            "onchange" => T<Function> ^-> TSelf

            "onafterchange" => T<Function> ^-> TSelf

            "oncomplete" => T<Function> ^-> TSelf

            "onstart" => T<Function> ^-> TSelf

            "onexit" => T<Function> ^-> TSelf

            "onskip" => T<Function> ^-> TSelf

            "onbeforeexit" => T<Function> ^-> TSelf

            // Hints

            "onhintsadded" => T<Function> ^-> TSelf

            "onhintclick" => T<Function> ^-> TSelf

            "onhintclose" => T<Function> ^-> TSelf

            "addHints" => T<unit> ^-> T<Promise<_>>[TSelf]

            "showHint" => T<int> ^-> T<Promise<_>>[TSelf]

            "showHints" => T<unit> ^-> T<Promise<_>>[TSelf]

            "removeHint" => T<int> ^-> TSelf

            "removeHints" => T<unit> ^-> TSelf

            "hideHint" => T<int> ^-> T<Promise<_>>[TSelf]

            "hideHints" => T<unit> ^-> T<Promise<_>>[TSelf]

            "showHintDialog" => T<int> ^-> T<Promise<_>>[TSelf]

        ]

    let _ =
        [
            // Main core styles
            "Main", "intro.js/introjs.css"
            "RTL", "intro.js/introjs-rtl.css"

            // Themes (from your `themes` folder)
            "Dark", "intro.js/themes/introjs-dark.css"
            "Flattener", "intro.js/themes/introjs-flattener.css"
            "Modern", "intro.js/themes/introjs-modern.css"
            "Nassim", "intro.js/themes/introjs-nassim.css"
            "Nazanin", "intro.js/themes/introjs-nazanin.css"
            "Royal", "intro.js/themes/introjs-royal.css"
        ]
        |> List.iter (fun (name, path) ->
            Styles
            |+> Static [
                name => T<unit> ^-> T<unit>
                |> ImportFile path
            ] |> ignore
        )

    let Assembly =
        Assembly [
            Namespace "WebSharper.IntroJS" [
                IntroJSClass
                HintConfigClass
                StepConfigClass
                OptionsClass
                Styles
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
