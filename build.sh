#!/bin/sh
exec dotnet wyam build -c config.wyam -i Docs/input -t Docs/theme -o wwwroot/docs
exec dotnet build -c Release
