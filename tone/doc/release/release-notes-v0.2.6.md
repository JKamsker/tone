# Release Notes

## Added
- Published `tone` as a .NET tool package on NuGet.org
- Exposed the CLI command as `tone` for `dotnet tool install`

## Changed
- Switched CLI version reporting to assembly/package metadata instead of source replacement during release
- Added release pipeline steps to pack and publish the NuGet tool with version pattern `0.0.<buildnum>`
- Normalized metadata format tests so release validation passes across line-ending differences

## Setup instructions

`tone` is released as single monolithic binary, so you don't need a setup file or any dependencies (not even a `.NET` runtime). Download the `tone`
release for your platform, extract it and run it via command line. If you need help choosing your download, here are some hints:

- For Windows, only the x64 platform is available... choose `-win-x64.zip`
- For `musl` (an alternative C library) choose your arch prefixed by `musl` (usually this is used in alpine `docker` images and other lightweight distributions)
- For standard Linux (like *Fedora*, *Ubuntu*, etc.), it is recommended choose your arch without `musl` prefix
- For *macOS* you might need to run `xattr -rd com.apple.quarantine tone` after extracting to remove `quarantine` flag
