Det vigtigste med det lille projekt her, er at vise hvordan man kan lave CI/CD - Continous Integration - Continous Delivery, 
når man Pusher ændringer i sin løsning ud på GitHub. Når jeg skriver løsning her er det fordi, at denne løsning sagtens og faktisk 
bør bestå af flere individuelle projekter.

Det helt essenielle for at få denne funktionalitet til at virke er, at man i sin løsning på GitHub har medtaget en *.yaml fil, 
der SKAL være placeret i mappen /github/workflows.

I projektet her er denne fil navngivet ci_cd.yaml. Indholdet af denne fil er vist herunder :

 -------------------------------------------------------------------------------------------------------------------------------------------------

name: .NET Core Build and Test

on: push: branches: - master pull_request: branches: - master

jobs: build: runs-on: windows-latest

steps:
- name: Checkout code
  uses: actions/checkout@v2

- name: Setup .NET Core SDK
  uses: actions/setup-dotnet@v3
  with:
    dotnet-version: '9.0.x'

- name: Install dependencies
  run: dotnet restore

- name: Build the project
  run: dotnet build --no-restore --configuration Release

- name: Run tests
  run: dotnet test --no-build --verbosity normal --configuration Release

  -------------------------------------------------------------------------------------------------------------------------------------------------

  Uden at være ekspert på indholdet af ci_cd.yaml vil jeg mene, at man stort set bare kan kopiere indholdet af denne fil til sit eget GitHub Repositorie,
  og så er man kørende med CI/CD. Det vil sige, at ens løsning bliver bygget og automatiske test cases, der er en del af ens løsning, bliver kørt automatisk,
  som vi kender det fra f.eks. Visual Studio. 
  Man skal måske lige ændre linjen med tekst : dotnet-version: '9.0.x' , hvis man bruger en anden Aso.Net version end 9 i sin egen løsning. 

  Hvis der opstår problemer med at bygge ens løsning og/eller en eller flere af de automatiske test cases, vil der blive sendt en mail til ejeren af det GitHub Repository,
  hvor løsningen er placeret. 

  Da jeg ikke lige kan finde ud af, at få GitHub til at sende en mail til mig, når der ikke er nogen fejl i byg og test, har jeg med vilje introduceret en fejl i én af test casene.
  Så vil jeg altid få en mail fra GitHub, når jeg har pushed ændringer herud. Tricket er så, at det kun er hvis, jeg får flere end den forventede éne fejl,
  at jeg behøver at reagere på det. Ellers er mailen med den éne forventede fejl bare en oplysning til mig om, at løsningen er bygget korrekt og at alle test cases er passed.  
