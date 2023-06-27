module.exports = {
  branches: "master",
  repositoryUrl: "https://github.com/ftrip-io/playground",
  plugins: [
    "@semantic-release/commit-analyzer",
    "@semantic-release/release-notes-generator",
    [
      "@semantic-release/changelog",
      {
        changelogFile: "CHANGELOG.md",
      },
    ],
    "@semantic-release/github",
  ],
};
