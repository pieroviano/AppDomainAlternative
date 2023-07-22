IF NOT DEFINED Configuration SET Configuration=Release
MSBuild.exe AppDomainAlternative.sln -t:clean
MSBuild.exe AppDomainAlternative.sln -t:restore -p:RestorePackagesConfig=true
MSBuild.exe AppDomainAlternative.sln -m /property:Configuration=%Configuration%
git add -A
git commit -a --allow-empty-message -m ''
git push