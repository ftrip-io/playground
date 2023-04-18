module.export = {
	branches: "master",
	repositoryUrl: "https://github.com/ftrip-io/playground",
	plugins: [
		'@semantic-release/commit-analyzer',
		'@semantic-release/release-notes-generator',
		"@semantic-release/github",
    [
      "@semantic-release/exec",
      {
        "prepareCmd": "set-version ${nextRelease.version}",
        "publishCmd": "publish-package"
      }
    ]
	]
}
	