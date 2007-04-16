#!/usr/bin/env python

"""Counts all the lines from a directory inward."""

import os
import os.path
import sys

lines = 0

bold = os.name == 'posix' and os.popen('tput bold').read() or ''
reset = os.name == 'posix' and os.popen('tput sgr0').read() or ''

for root, dirs, files in os.walk(os.getcwd()):
    lines_in_dir = 0
    for name in files:
        if os.path.splitext(os.path.basename(name))[1] in ('.py', '.html', '.cs'):
            lines_in_dir += len(open(os.path.join(root, name), 'rU').readlines())
    in_dir = root.replace(os.getcwd(), '') and root.replace(os.getcwd(), '') or '.'
    print '    %-4i in %s' % (lines_in_dir, in_dir)
    lines += lines_in_dir

sys.stdout.write(bold)
print '    %-4i total lines' % (lines)
sys.stdout.write(reset)