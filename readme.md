# DocFX Setup:
- create sample project
- install docfx :
- ```
    dotnet tool update -g docfx --version 2.60.0-preview.1
    docfx init --output documentation
- edit docfx.json and update src directory to the project src directory
- ```
  cd documentation
- ```
  docfx --serve
- use xml documentation to document api endpoints
- add custom theme:
    - git clone https://github.com/jbltx/DiscordFX.git templates
    - edit docfx.json:
      ```json
      "template": [
        "default",
        "templates/discordfx"
      ]
    - ```
      docfx --serve