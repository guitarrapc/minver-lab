minver-lab

## Q&A

If there are no tag at all, then minver will use `0.0.0-alpha.0.number_of_commits_since_last_tag`

```bash
# if there are already 2 commits
$ dotnet minver
0.0.0-alpha.0.2
```

**Change pre-release tag**

You can change prerelease tag with `-p prerelease_tag` option.

```shell
$ dotnet minver -p preview
0.0.0-preview.2
```

`-p` also allow you can specify the tag to the current date and time.

```shell
$ dotnet minver -p preview-20241210170610
0.0.0-preview-20241210170610.2
```

**Remove height part of the version**

Use `-i` option to remove the height part of the version.

```shell
$ dotnet minver -p preview-20241210170610 -i
0.0.0-preview-20241210170610
```

**Update version and get result**

locally git tag, and run minver to retrieve the version.

```shell
$ git tag 0.1.0
$ dotnet minver
0.1.0
```

**Use v prefix for the version**

Use `-t` option to add `v` prefix to the version.

```shell
$ git tag v0.1.0
$ dotnet minver -t v
0.1.0
```

## Practical use

**Make preview release with the current date and time for every PR.**

If you already released `0.1.0`, and you want to make a preview release for every PR for `0.1.1-preview-yyyyMMddHHss` then try following.

```shell
$ dotnet minver -p preview-20241210170610
```
