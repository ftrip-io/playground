module.export = {
	branches: "master",
	repositoryUrl: "https://github.com/ftrip-io/playground.git",
	plugins: [
		'@semantic-release/commit-analyzer',
		'@semantic-release/release-notes-generator',
		'@semantic-release/github'
	]
}
	