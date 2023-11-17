# release args

```ini
is_clang=false
visual_studio_version="2022"

# Make the smallest release
is_debug = false
is_official_build=true
strip_debug_info=true
symbol_level=0

# Don't need these features
dawn_use_angle=false
dawn_use_swiftshader=false

#disable custom versions of libs
use_custom_libcxx = false
dawn_use_built_dxc = false

#only one output library
dawn_complete_static_libs = true

```