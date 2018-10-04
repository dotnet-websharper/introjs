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
open WebSharper.InterfaceGenerator

module Definition =

    let StepConfigClass =
        Pattern.Config "StepConfig" {
            Required = []
            Optional = 
                [
                    "intro", T<string>
                    "element", T<JavaScript.Dom.Element>
                    "position", T<string>
                ]
        }

    let HintConfigClass =
        Pattern.Config "HintConfig" {
            Required = []
            Optional = 
                [
                    "hint", T<string>
                    "element", T<JavaScript.Dom.Element>
                    "position", T<string>
                    "hintPosition", T<string>
                ]
        }

    let OptionsClass =
        Pattern.Config "Options" {
            Required = []
            Optional =
                [
                    "steps", !| StepConfigClass.Type
                    "nextLabel", T<string>
                    "prevLabel", T<string>
                    "doneLabel", T<string>
                    "hidePrev", T<bool>
                    "hideNext", T<bool>
                    "tooltipPostition", T<string>
                    "tooltipClass", T<string>
                    "hightlightClass", T<string>
                    "exitOnEsc", T<bool>
                    "exitOnOverlayClick", T<bool>
                    "showStepNumbers", T<bool>
                    "keyboardNavigation", T<bool>
                    "showButtons", T<bool>
                    "showBullets", T<bool>
                    "showProgress", T<bool>
                    "scrollToElement", T<bool>
                    "overlayOpacity", T<JavaScript.Number>
                    "disableInteraction", T<bool>
                ]
        }

    let HintOptionsClass =
        Pattern.Config "HintOptions" {
            Required = []
            Optional = 
                [
                    "hintPosition", T<string>
                    "hintButtonLabel", T<string>
                    "hintAnimation", T<bool>
                ]
        }

    let IntroJSClass =
        Class "introJs"
        |+> Static [
            Constructor (!? T<string>)
        ]
        |+> Instance [
            "start" => T<unit> ^-> TSelf

            "goToStep" => T<int> ^-> TSelf

            "addStep" => StepConfigClass.Type ^-> T<unit>

            "addSteps" => !| StepConfigClass.Type ^-> T<unit>

            "nextStep" => T<unit> ^-> TSelf

            "previousStep" => T<unit> ^-> TSelf

            "exit" => T<unit> ^-> TSelf

            "setOption" => T<string> * T<string> ^-> TSelf

            "setOptions" => (OptionsClass.Type ^-> TSelf) + (HintOptionsClass.Type ^-> TSelf)

            "refresh" => T<unit> ^-> TSelf

            "oncomplete" => T<JavaScript.Function> ^-> TSelf

            "onexit" => T<JavaScript.Function> ^-> TSelf

            "onchange" => T<JavaScript.Function> ^-> TSelf

            "onbeforechange" => T<JavaScript.Function> ^-> TSelf

            "onafterchange" => T<JavaScript.Function> ^-> TSelf

            // Hints

            "addHints" => T<unit> ^-> TSelf

            "showHint" => T<int> ^-> TSelf

            "showHints" => T<unit> ^-> TSelf

            "hideHint" => T<int> ^-> TSelf

            "hideHints" => T<unit> ^-> TSelf

            "onhintclick" => T<JavaScript.Function> ^-> TSelf

            "onhintsadded" => T<JavaScript.Function> ^-> TSelf

            "onhintclose" => T<JavaScript.Function> ^-> TSelf

        ]

    let Assembly =
        Assembly [
            Namespace "WebSharper.IntroJS.Resources" [
                Resource "Js" "https://cdnjs.cloudflare.com/ajax/libs/intro.js/2.5.0/intro.min.js" 
                |> AssemblyWide

                Resource "MainTheme" "https://cdnjs.cloudflare.com/ajax/libs/intro.js/2.5.0/introjs.min.css"

                Resource "RTLTheme" "https://cdnjs.cloudflare.com/ajax/libs/intro.js/2.5.0/introjs-rtl.min.css"

                Resource "DarkTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-dark.css"

                Resource "FlattenerTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-flattener.css"

                Resource "ModernTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-modern.css"

                Resource "NassimTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-nassim.css"
            
                Resource "NazaninTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-nazanin.css"

                Resource "RoyalTheme" "https://cdn.rawgit.com/usablica/intro.js/4c364c90/themes/introjs-royal.css"
            ]
            Namespace "WebSharper.IntroJS" [
                IntroJSClass
                HintOptionsClass
                HintConfigClass
                StepConfigClass
                OptionsClass
            ]
        ]


[<Sealed>]
type Extension() =
    interface IExtension with
        member x.Assembly = Definition.Assembly

[<assembly: Extension(typeof<Extension>)>]
do ()
