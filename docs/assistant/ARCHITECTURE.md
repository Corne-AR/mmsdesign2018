MMS Design — Architecture Overview
Solution & Projects

MMS Design (WinForms application)

Role: Entry point / shell; composes the UI and launches core flows.

Key files: Program.cs, App.config, resources & icons, ClickOnce publish/.

References: Links to project outputs (AMS.dll, Data.dll, AMS Script.dll, AMS Certificate.dll) and DevExpress Win assemblies.

AMS (Core platform & shared UI)

Role: Cross-cutting infrastructure: messaging, security/crypto, IO helpers, utilities, suite theming, common WinForms controls and dialogs.

Notable areas:

Communications/ (MAPI, MailManager + forms)

Security/ (AES/Encryption, activation UI)

Utilities/ (collections/string helpers, reusable controls)

Suite/ (LocalPreferences, Maintenance, Theme colors + editor)

Forms/MessageBox & Forms/Log (custom dialogs, logger viewers)

Data (Domain model & business logic)

Role: Business entities + calculations + managers (no Firebase).

Notable areas:

Accounts/ (Receipts, allocations, process prefs)

Products/, Catalogs/, Quotes/, Reports/ (financial statements, VAT payable, etc.)

People/ (Client/Company/Person, maintenance schedule)

Search/ (search data & ranges), Schedule/ (course/events), Logger/ (Work/Time log)

Utilities/ProgramUtilities.cs

AMS Script (Scripting subsystem)

Role: Scripting commands, editor UI, and script execution glue.

Key areas: Commands/ (Maths, Variable), Script/ (types + engine), forms for Factor/Script editor.

AMS Certificate (Certificates module)

Role: Issuing certificates & managing course attendees (WinForms forms + resources).

ReportManager (Reporting host)

Role: WPF/XAML report tooling + MVVM helpers for designing/previewing reports, plus DevExpress reporting integration.

Key areas: Views/ (ReportDesigner/ReportWindow), MVVM/ (commands, base VM), ReportManager.cs.

UserInterface (Feature UIs grouped by domain)

Role: End-user screens (WinForms) by area: Main/ (MainForm, StartUp), IO/ (Export, Products), Quotes/ (workflow .cd), Accounting/, People/, Products/, Transactions/, Utilities/ resources.

References/DevExpress (3rd-party libs)

Role: DevExpress v17.1 DLLs for WinForms/WPF/Reporting.

Evidence: project folders and files listed in the repo (solutions, projects, XAML/WinForms forms, resources, DevExpress assemblies). 

directory_structure

Layered Responsibilities

UI Layer

WinForms: MMS Design, UserInterface, WinForms forms under AMS (dialogs, message boxes).

WPF Host for reports: ReportManager (XAML views + MVVM helpers).

Application/Services Layer

AMS: cross-cutting services (communications/MAPI mailer, security, suite theming, reusable UI controls, logging viewers).

Domain Layer

Data: business entities, calculations (quotes/maintenance), managers (accounts, catalog, search, schedule), and reporting models (financial year, VAT).

Automation/Scripting

AMS Script: script model, commands, and editors for automating tasks.

Certificates

AMS Certificate: UI + resources to issue model/course certificates.

Data & Integrations (Current)

Local/XML/Filesystem first: Entities (clients/companies/transactions/receipts etc.) are modeled in Data/* and persisted traditionally (no cloud sync in code).

Email: MAPI-based email composition/sending via AMS/Communications.

Reporting: DevExpress v17.1 (WinForms/WPF) assembly set in References/DevExpress.

No Firebase: Firebase syncing logic has been fully removed/abandoned.

Evidence: MAPI/Mail classes in AMS; reporting DLLs; absence of Firebase libraries/config. 

directory_structure

Build & Tooling

Target Framework: .NET Framework 4.7.1 across projects.

IDE split:

VS2017 – authoritative build/debug/reports (DevExpress v17).

VS2022 – editing only (Copilot/IntelliSense).

Isolated outputs: Directory.Build.props routes VS2017 → bin\vs2017\..., VS2022 → bin\vs2022\....

ClickOnce: MMS Design/publish/ contains ClickOnce artifacts (.application, setup.exe, Application Files/*).

Evidence: per-project obj/bin plus vs2017/vs2022 subpaths and ClickOnce files in MMS Design/publish. 

directory_structure

High-Level Data Flow

MMS Design (WinForms) boots (Program.cs) and shows MainForm (UserInterface/Main).

UI actions call into Data (domain objects & calculators) and AMS (shared services: dialogs, mail, security).

Reporting flows route through ReportManager (WPF designer/preview; DevExpress).

Scripting flows go via AMS Script (commands + editor).

Certificates UI uses AMS Certificate.

All assemblies and DevExpress libs are deployed next to the app (no remote sync).

Evidence: presence of Program.cs, MainForm, Data calculators/managers, WPF report views, scripting commands/editors, certificate forms. 

directory_structure

Conventions & Do/Don’t

Do keep designer files (*.Designer.cs) auto-generated; do not hand-edit.

Do keep public APIs stable; use private helpers for refactors.

Don’t retarget beyond .NET 4.7.1.

Don’t introduce C# 8+ features; stick to C# ≤ 7.3.

Don’t add packages/upgrades without explicit approval (DevExpress stays v17.1).

Evidence: WinForms/WPF designer files, DevExpress 17.1 assemblies in References/DevExpress. 

directory_structure

Glossary (Short)

AMS: Shared infrastructure & UI components.

Data: Business/domain layer.

ReportManager: WPF host + DevExpress reporting tools.

AMS Script: Scripting engine + editors.

AMS Certificate: Certificates & attendees.

MMS Design: App shell & entry point.

Removed / Deprecated

Firebase sync: Removed; no cloud sync remains. Local/desktop workflow only.

What’s next (recommended)

Replace the old doc: Save this as /docs/assistant/ARCHITECTURE.md.

Refresh the assistant’s ground truth:

Update /docs/assistant/SYSTEM_PROMPT.md to explicitly say “Firebase is removed; prefer local file-based flows.”

Re-index your repo (so the GPT agent searches the new docs first).

Pick a first optimization target (safe, visible win):

Suggestion: UserInterface/Main/MainForm.cs startup path + AMS/Suite theming & Data/Quotes/Quote.cs calculation guards.

I’ll propose ≤2 surgical patches per file with exact file/anchor/line hints.

Create KNOWN_BUGS items for anything still biting you (e.g., email flows, report designer quirks) so GPT can prioritize fixes.