
# Getting Started

## Install
Install [Git Large File Storage (LFS)](https://docs.github.com/en/repositories/working-with-files/managing-large-files/installing-git-large-file-storage)

Install [Node.js and npm](https://docs.npmjs.com/downloading-and-installing-node-js-and-npm)
Then, in the project root directory, install all dependencies.
```
npm install
```
## Develop
### Create a fork of the `develop` branch

### Follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) guidelines when writing commits and pull requests
#### Structure:

```
<type>[optional scope]: <description>

[optional body]

[optional footer(s)]

```

#### Commit types:

| Commit Type | Title | Description
| ----------- | ------------------------ | -----------------------------------------------------------------------------------------------------------
| `feat` | Features | A new feature
| `fix` | Bug Fixes | A bug Fix
| `docs` | Documentation | Documentation only changes
| `style` | Styles | Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
| `refactor` | Code Refactoring | A code change that neither fixes a bug nor adds a feature
| `perf` | Performance Improvements | A code change that improves performance
| `test` | Tests | Adding missing tests or correcting existing tests
| `build` | Builds | Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
| `ci` | Continuous Integrations | Changes to our CI configuration files and scripts (example scopes: Travis, Circle, BrowserStack, SauceLabs)
| `chore` | Chores | Other changes that don't modify src or test files
| `revert` | Reverts | Reverts a previous commit

#### Examples:
Commit message with no body
```
docs: correct spelling of CHANGELOG
```
Commit message with scope
```
feat(lang): add Polish language
```
Commit message with multi-paragraph body
```
fix: prevent racing of requests

Introduce a request id and a reference to latest request. Dismiss
incoming responses other than from latest request.

Remove timeouts which were used to mitigate the racing issue but are
obsolete now.
```

### Create pull requests into the `develop` branch (NOT the `main` branch)