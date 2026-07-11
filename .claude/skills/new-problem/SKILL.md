---
name: new-problem
description: このスキルは、ユーザーが「(カテゴリ)に(問題名)を追加して」「新しいLeetCode問題フォルダを作って」「◯◯という問題を追加して」のように、このリポジトリに新しいLeetCode解答用フォルダを追加してほしいときに使う。
version: 1.0.0
---

# New Problem Skill

新しいLeetCode問題用のフォルダを、`.csproj`付きでこのリポジトリに追加し、`arai60.slnx`に登録する。

## 手順

1. **カテゴリ(Category)を決める**
   - リポジトリ直下のトップレベルフォルダ(`Heap`, `Stack`, `LInkedList` など)から、問題の性質に合うものを選ぶ。
   - どれにも当てはまらない/新しいカテゴリが必要そうな場合はユーザーに確認する。

2. **フォルダ名(Name)を決める**
   - 既存の命名規則に合わせる: `{LeetCode問題番号}_{問題名}` (例: `347_Top K Frequent Elements`)。スペース区切りの問題名をそのまま使ってよい。
   - 問題番号が不明な場合はユーザーに確認するか、番号なしで問題名のみ(例: `LinkedListCycle`)にする。番号を推測で捏造しない。

3. **スクリプトを実行する**(リポジトリルートで実行)
   ```powershell
   .\New-Problem.ps1 -Category "<Category>" -Name "<Name>"
   ```
   - フォルダ作成、`.csproj`配置、`Main.cs`雛形(`public class Solution {}`)作成、`arai60.slnx`への登録を自動で行う。
   - 既に同名フォルダが存在する場合はエラーで停止するので、上書きせず名前をユーザーに確認する。

4. **ビルドして確認する**
   ```bash
   dotnet build "<Category>/<Name>/<Name>.csproj"
   ```
   - `0 エラー`であることを確認する。

5. **結果を報告する**
   - 作成したフォルダのパスを伝える。
   - `Main.cs`は空のSolutionクラス雛形であり、実装はユーザー自身が書く前提であることを伝える。

## 注意

- `New-Problem.ps1`はリポジトリルート(`arai60.slnx`と同じ階層)に存在する前提。
- フォルダ名にスペースを含む場合、PowerShell/Bash双方でダブルクォートで囲む。
