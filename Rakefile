ASSEMBLY_INFO = 'src/RestEase/Properties/AssemblyInfo.cs'
NUSPEC = 'NuGet/RestEase.nuspec'
SLN = 'src/RestEase.sln'
CSPROJ = 'src/RestEase/RestEase.csproj'
TESTS_CSPROJ = 'src/RestEaseUnitTests/RestEaseUnitTests.csproj'
MSBUILD = %q{C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe}

GITLINK_REMOTE = 'https://github.com/canton7/RestEase'

desc "Create NuGet package"
task :package do
  local_hash = `git rev-parse HEAD`.chomp
  sh "NuGet/GitLink.exe . -c \"Release 4.0\" -s #{local_hash} -u #{GITLINK_REMOTE} -f src/RestEase.sln -ignore RestEaseUnitTests"
  sh "NuGet/GitLink.exe . -c \"Release 4.5\" -s #{local_hash} -u #{GITLINK_REMOTE} -f src/RestEase.sln -ignore RestEaseUnitTests"
  Dir.chdir(File.dirname(NUSPEC)) do
    sh "nuget.exe pack #{File.basename(NUSPEC)}"
  end
end

desc "Bump version number"
task :version, [:version] do |t, args|
  parts = args[:version].split('.')
  parts << '0' if parts.length == 3
  version = parts.join('.')

  content = IO.read(ASSEMBLY_INFO)
  content[/^\[assembly: AssemblyVersion\(\"(.+?)\"\)\]/, 1] = version
  content[/^\[assembly: AssemblyFileVersion\(\"(.+?)\"\)\]/, 1] = version
  File.open(ASSEMBLY_INFO, 'w'){ |f| f.write(content) }

  content = IO.read(NUSPEC)
  content[/<version>(.+?)<\/version>/, 1] = args[:version]
  File.open(NUSPEC, 'w'){ |f| f.write(content) }
end

desc "Build the project for release"
task :build do
  sh MSBUILD, SLN, "/t:Clean;Rebuild", "/p:Configuration=Release 4.0", "/verbosity:normal"
  sh MSBUILD, SLN, "/t:Clean;Rebuild", "/p:Configuration=Release 4.5", "/verbosity:normal"
end