# DocFX Setup:
- create sample project
- install docfx :
- ```
    dotnet tool update -g docfx --version 2.60.0-preview.1
    docfx init --output documentation
  ```
- edit docfx.json and update src directory to the project src directory
- use xml documentation to document api endpoints
- ```cd documentation```
- ```docfx --serve```
- add custom theme:
    - ```git clone https://github.com/jbltx/DiscordFX.git templates```
    - edit docfx.json:
      ```json
      "template": [
        "default",
        "templates/discordfx"
      ]
      ```
    - ```
      docfx --serve
      ```
- ***Does not support open api/ swagger v3 api documentation (supports swagger v2), support planned to be added in docfx v3
- the static web contents are inside documentation/_site directory
- on merge to master, we can run the ```docfx -serve``` command and publish the contents of _site directory to our documentation site directory
