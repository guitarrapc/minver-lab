minver-lab

MinVer will geenrate the version based on the git tag. The format of the version is `{major}.{minor}.{patch}-{prerelease}.{height}`. The prerelease is optional, and the height is the number of commits since the last tag.

If you run minver right after the tag, then the height will not shown.

```shell
$ git tag 0.1.0
$ minver
0.1.0
```

If you commit after tag, then the height will be shown as number of commits.

```shell
$ git tag 0.1.0
$ git commit -m "commit after tag"
$ git commit -m "commit after tag2"
$ minver
0.1.1-alpha.2
```

## Q&A

**Change pre-release tag**

You can change prerelease tag `-alpha` with custom message, use `-p prerelease_tag` option.

```shell
# change -alpha to -preview
$ dotnet minver -p preview
0.1.1-preview.2
```

`-p` also allow you can specify the tag to the current date and time.

```shell
$ dotnet minver -p preview-20241210170610
0.1.1-preview-20241210170610.2
```

**Remove height part of the version**

Use `-i` option to remove the height part of the version.

```shell
$ dotnet minver -p preview-20241210170610 -i
0.1.1-preview-20241210170610
```

**Update version and get result**

locally git tag, and run minver to retrieve the version.

```shell
$ git tag 0.2.0
$ dotnet minver
0.2.0
```

**Use v prefix for the version**

Use `-t` option to add `v` prefix to the version.

```shell
$ git tag v0.2.0
$ dotnet minver -t v
0.2.0
```

## Practical use

**Make preview release with the current date and time for every PR.**

If you already released `0.1.0`, and you want to make a preview release for every PR for `0.1.1-preview-yyyyMMddHHss.{height}` then try following.

```shell
$ dotnet minver -p preview-20241210170610
0.1.1-preview-20241210170610.1
```

**Make new tag and use it to update some files**

If you want update some file's version string before push tag, then you can use following command.

```shell
git tag 0.1.1
version=$(dotnet minver) # you will get 0.1.1

# .... update any file

git push origin 0.1.1
```
