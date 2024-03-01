# Getting Started

## 1. Install Git Large File Storage (LFS)
https://docs.github.com/en/repositories/working-with-files/managing-large-files/installing-git-large-file-storage

## 2. Create a fork of this repository

## 3. Follow Conventional Commits guidelines when writing commits.
Structure:
```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]
```
## Commit types

| Commit Type | Title                    | Description                                                                                                 
| ----------- | ------------------------ | ----------------------------------------------------------------------------------------------------------- 
| `feat`      | Features                 | A new feature                                                                                               
| `fix`       | Bug Fixes                | A bug Fix                                                                                                   
| `docs`      | Documentation            | Documentation only changes                                                                                  
| `style`     | Styles                   | Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)      
| `refactor`  | Code Refactoring         | A code change that neither fixes a bug nor adds a feature                                                   
| `perf`      | Performance Improvements | A code change that improves performance                                                                     
| `test`      | Tests                    | Adding missing tests or correcting existing tests                                                           
| `build`     | Builds                   | Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)         
| `ci`        | Continuous Integrations  | Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs) 
| `chore`     | Chores                   | Other changes that don't modify src or test files                                                           
| `revert`    | Reverts                  | Reverts a previous commit                                                                                   