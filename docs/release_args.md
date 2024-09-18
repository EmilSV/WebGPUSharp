# release args

```ini
is_clang = true

# Make the smallest release
is_debug = false
strip_debug_info=true
symbol_level=0

# Don't need these features
dawn_use_angle=false
dawn_use_swiftshader=false

#disable custom versions of libs
use_custom_libcxx = false
enable_rust=false
dawn_use_built_dxc = false

#only one output library
dawn_complete_static_libs = true
chrome_pgo_phase = 0
treat_warnings_as_errors = false
is_official_build = true

```